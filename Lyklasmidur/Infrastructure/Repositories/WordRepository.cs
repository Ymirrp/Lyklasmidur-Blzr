using Lyklasmidur.Core.Models;
using Lyklasmidur.Core.Repositories;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Text;

namespace Lyklasmidur.Infrastructure.Repositories
{
    public class WordRepository : IWordRepository
    {
        private readonly ILogger<WordRepository> _logger;
        private DataTable Data;

        public WordRepository(ILogger<WordRepository> logger)
        {
            _logger = logger;
            Data = LoadData();

        }

        public async Task<Word> GetWord(WordType type)
        {
            List<Word> wordsOfType = [.. Data.AsEnumerable()
                .Where(row => row.Field<string>("type") == type.ToString())
                .Select(row => new Word
                {
                    Value = row.Field<string>("value") ?? string.Empty,
                    Type = type
                })];

            return wordsOfType[Random.Shared.Next(wordsOfType.Count)]
                ?? new() { Type = type, Value = String.Empty };
        }

        private DataTable LoadData()
        {
            DataTable data = new();
            try
            {
                using TextFieldParser csvReader = new(@"Infrastructure/Repositories/Data/words.csv", Encoding.GetEncoding("ISO-8859-1"));
                csvReader.SetDelimiters(",");
                csvReader.HasFieldsEnclosedInQuotes = true;
                string[]? colFields = csvReader.ReadFields();

                foreach (string column in colFields ?? [])
                {
                    DataColumn datecolumn = new(column)
                    {
                        AllowDBNull = true
                    };
                    data.Columns.Add(datecolumn);
                }
                int c = 0;
                while (!csvReader.EndOfData)
                {
                    string[]? fieldData = csvReader.ReadFields();
                    if (fieldData is null)
                        continue;
                    object[] rowData = [
                        fieldData[0] switch
                        {
                            "a" => WordType.Adjective,
                            "v" => WordType.Verb,
                            _ => WordType.Noun
                        }, fieldData[1]];

                    data.Rows.Add(rowData);
                    c++;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading words from CSV.");
            }

            return data;
        }
    }
}
