using AutoCompleteTextBox.Editors;
using NewEva.Model;
using System.Collections;

namespace NewEva
{
    public class AddressSuggestionProvider : ISuggestionProvider
    {
        public IEnumerable GetSuggestions(string filter)
        {
            var isCorrect = DadataService.GetSuggestions(filter, out Address[] address);
            if (isCorrect != false)
            {
                foreach (var adr in address)
                {
                    yield return adr;
                }
            }
        }
    }
}
