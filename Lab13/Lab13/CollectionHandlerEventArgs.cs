using System;
using Human;
using System.Collections.Generic;

namespace Lab13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; private set; }

        public ChangeType ChangeType { get; private set; }

        public Dictionary<int, IHuman> IndexDataPairs { get; private set; }

        public DateTime ChangeTime { get; private set; }

        public CollectionHandlerEventArgs(string collectionName, ChangeType changeType, Dictionary<int, IHuman> indexDataPairs)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            IndexDataPairs = indexDataPairs;
            ChangeTime = DateTime.Now;
        }

        public override string ToString()
        {
            if (IndexDataPairs.Count == 0)
                return "";

            string output = $"CHANGE TIME: {ChangeTime}\n" +
                $"COLLECTION NAME: {CollectionName}\n" +
                $"CHANGE TYPE: {ChangeType}\n";

            if (IndexDataPairs.Count > 1)
            {
                if (ChangeType == ChangeType.Add)
                    output += "ADDED OBJECTS:\n";
                if (ChangeType == ChangeType.Remove)
                    output += "REMOVED OBJECTS:\n";
                if (ChangeType == ChangeType.Reference)
                    output += "NEW OBJECTS:\n";
            }
            else
            {
                if (ChangeType == ChangeType.Add)
                    output += "ADDED OBJECT:\n";
                if (ChangeType == ChangeType.Remove)
                    output += "REMOVED OBJECT:\n";
                if (ChangeType == ChangeType.Reference)
                    output += "NEW OBJECT:\n";
            }

            foreach (KeyValuePair<int, IHuman> data in IndexDataPairs)
                output += $"• [{data.Key}] {data.Value}\n";

            return output;
        }
    }
}
