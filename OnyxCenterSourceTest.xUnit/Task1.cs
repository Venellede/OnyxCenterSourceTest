using OnyxCenterSourceTest.Tasks.Task1;

namespace OnyxCenterSourceTest.xUnit
{
    public class Task1
    {
        [Fact]
        public async Task GetAllDuplicateGuests()
        {
            var question = new InvoiceGroup[0];
            var result = question.GetAllDuplicateGuests();
        }

        [Fact]
        public async Task GetNumberOfNightsForAgents()
        {
            var question = new InvoiceGroup[0];
            var result = question.GetNumberOfNightsForAgents();
        }
    }
}
