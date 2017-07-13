using SecNotify.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SecNotify.Data
{
    public class LocationDataImporter
    {
        private static bool IsDataLoaded = false;

        internal static void LoadData(LocationData locationData)
        {

            if (IsDataLoaded)
            {
                return;
            }

            List<string[]> rows = new List<string[]>();

            using (StreamReader reader = File.OpenText("D:/Documents/LC101/SecNotify/SecNotify/Data/locations.csv"))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] rowArrray = CSVRowToStringArray(line);
                    if (rowArrray.Length > 0)
                    {
                        rows.Add(rowArrray);
                    }
                }
            }

            string[] headers = rows[0];
            rows.Remove(headers);

            /**
             * Parse each row array into a Location object.
             * Assumes CSV column ordering: 
             *      name,displayphone,SMSphone
             */
            foreach (string[] row in rows)
            {
                Location newLocation = new Location
                {
                    Name = row[0],
                    DisplayPhone = row[1],
                    SMSPhone = row[2]
                };
                locationData.Locations.Add(newLocation);
            }

            IsDataLoaded = true;
        }

        /**
        * Parse a single line of a CSV file into a string array
        */
        private static string[] CSVRowToStringArray(string row, char fieldSeparator = ',', char stringSeparator = '\"')
        {
            bool isBetweenQuotes = false;
            StringBuilder valueBuilder = new StringBuilder();
            List<string> rowValues = new List<string>();

            // Loop through the row string one char at a time
            foreach (char c in row.ToCharArray())
            {
                if ((c == fieldSeparator && !isBetweenQuotes))
                {
                    rowValues.Add(valueBuilder.ToString());
                    valueBuilder.Clear();
                }
                else
                {
                    if (c == stringSeparator)
                    {
                        isBetweenQuotes = !isBetweenQuotes;
                    }
                    else
                    {
                        valueBuilder.Append(c);
                    }
                }
            }

            // Add the final value
            rowValues.Add(valueBuilder.ToString());
            valueBuilder.Clear();

            return rowValues.ToArray();
        }
    }
}
