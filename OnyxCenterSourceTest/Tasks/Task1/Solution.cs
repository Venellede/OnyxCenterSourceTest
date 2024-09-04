namespace OnyxCenterSourceTest.Tasks.Task1
{
    public static class Solution
    {
        //A
        public static IEnumerable<string> GetAllDuplicateGuests(this IEnumerable<InvoiceGroup> invoiceGroups)
        {
            return invoiceGroups
                .SelectMany(g => g.Invoices)
                .SelectMany(i => i.Observations)
                .GroupBy(o => o.GuestName)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key);
        }

        //B
        public static IEnumerable<TravelAgentInfo> GetNumberOfNightsForAgents(this IEnumerable<InvoiceGroup> invoiceGroups, int year = 2015)
        {
            return invoiceGroups
                .Where(g => g.IssueDate.Year == year)
                .SelectMany(g => g.Invoices)
                .SelectMany(i => i.Observations)
                .GroupBy(o => o.TravelAgent)
                .Select(g => new TravelAgentInfo { TravelAgent = g.Key, TotalNumberOfNights = g.Sum(x => x.NumberOfNights) });
        }

        //C
        public const string TravelAgentsWithoutObservations = @"
SELECT t.*
FROM TravelAgent AS t
LEFT JOIN Observation AS o ON o.TravelAgent = t.TravelAgent
WHERE o.TravelAgent IS NULL";

        //D
        public const string TravelAgentsWithObservations = @"
SELECT t.*
FROM TravelAgent AS t
LEFT JOIN Observation AS o ON o.TravelAgent = t.TravelAgent
GROUP BY o.TravelAgent
HAVING COUNT(o.TravelAgent) >= @minObservationsAmount";
    }
}
