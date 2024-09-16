using QD_Checklists.Models;
using System.Reflection;

namespace QD_Checklists.Helpers
{
    class TreeHierarchy
    {
        // Generic method to build a tree hierarchy
        public static List<TreeItem> Build<T>(
            List<T> items,
            List<string> hierarchyFields
        )
        {
            // Validate the input
            if (hierarchyFields == null || hierarchyFields.Count == 0)
            {
                throw new ArgumentException("Hierarchy fields must not be null or empty.");
            }

            // Helper method to get property value dynamically
            object? GetPropertyValue(T item, string propertyName)
            {
                PropertyInfo? property = typeof(T).GetProperty(propertyName);
                if (property == null)
                {
                    throw new ArgumentException($"Property '{propertyName}' not found on type '{typeof(T).Name}'.");
                }

                var propertyValue = property.GetValue(item);
                if (propertyValue == null)
                {
                    throw new ArgumentException($"Property '{propertyName}' value is null on type '{typeof(T).Name}'.");
                }

                // If property is a complex type, get the Name property
                if (propertyValue.GetType().GetProperty("Name") != null)
                {
                    return propertyValue.GetType().GetProperty("Name")?.GetValue(propertyValue);
                }

                return propertyValue;
            }

            // Recursive method to build tree nodes
            List<TreeItem> BuildTree(IEnumerable<T> itemGroup, int level)
            {
                if (level >= hierarchyFields.Count - 1)
                {
                    // Base case: Create leaf nodes
                    return itemGroup.Select(item => new TreeItem
                    (
                        GetPropertyValue(item, hierarchyFields.Last())?.ToString() ?? "Unknown",
                        GetPropertyValue(item, "Id") is int id ? id : 0
                    )).ToList();
                }

                var key = hierarchyFields[level];
                var groupedItems = itemGroup.GroupBy(item => GetPropertyValue(item, key)?.ToString());

                var treeItems = new List<TreeItem>();

                foreach (var group in groupedItems)
                {
                    var childNode = new TreeItem
                    (
                        group.Key ?? "Unknown", // Handle null keys
                        0 // Or some logic to assign a unique Id if needed
                    ) {
                        Children = BuildTree(group, level + 1) // Recursively build children
                    };

                    treeItems.Add(childNode);
                }

                return treeItems;
            }

            // Start building the tree from level 0
            return BuildTree(items, 0);
        }
    }
}
