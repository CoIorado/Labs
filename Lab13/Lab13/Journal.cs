using System;
using System.Collections.Generic;

namespace Lab13
{
    public class Journal
    {
        private List<JournalEntry> EntryList { get; set; }

        public Journal()
        {
            EntryList = new List<JournalEntry>();
        }

        public void CollectionReferenceChanged(object sender, CollectionHandlerEventArgs args)
        {
            JournalEntry journalEntry = new JournalEntry(sender, args.CollectionName, args.ChangeType, args.IndexDataPairs);
            EntryList.Add(journalEntry);
        }

        public void CollectionCountChanged(object sender, CollectionHandlerEventArgs args)
        {
            JournalEntry journalEntry = new JournalEntry(sender, args.CollectionName, args.ChangeType, args.IndexDataPairs);
            EntryList.Add(journalEntry);
        }

        public override string ToString()
        {
            if (EntryList.Count == 0)
                return "";

            string output = default;
            foreach (JournalEntry entry in EntryList)
            {
                output += entry.ToString() + "\n";
            }

            return output;
        }
    }
}
