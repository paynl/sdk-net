using System.Reflection;
using System.Text;
using PayNlSdk.Sdk.Utilities;

namespace PayNlSdk.IntegrationTests.JsonUtils;

public class JsonConverterTests
{
	class TestType
	{
		public List<string> List { get; set; }
		public IEnumerable<string> IEnumerable { get; set; }
		public ICollection<string> ICollection { get; set; }
		public IList<string> IList { get; set; }
	}

	class NestedListType
	{
		public List<List<string>> NestedLists { get; set; }
		public List<List<List<string>>> DeeplyNestedLists { get; set; }
	}

	[Fact]
	public async Task WritesEmptyArrayOnString()
	{
		var jsonString = new StringBuilder().Append("""
		                                            {
		                                                "List": "",
		                                                "IEnumerable": "",
		                                                "ICollection": "",
		                                                "IList": ""
		                                            }
		                                            """)
			.ToString();
		var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
		var obj = await Json.DeserializeAsync<TestType>(stream);
		Assert.NotNull(obj);
		Assert.Empty(obj.List);
		Assert.Equal("List`1", obj.List.GetType().Name);
		Assert.Empty(obj.IEnumerable);
		Assert.Equal("List`1", obj.IEnumerable.GetType().Name);
		Assert.Empty(obj.ICollection);
		Assert.Equal("List`1", obj.ICollection.GetType().Name);
		Assert.Empty(obj.IList);
		Assert.Equal("List`1", obj.IList.GetType().Name);
	}

	[Fact]
	public async Task CanStillWriteValidLists()
	{
		var jsonString = new StringBuilder().Append("""
		                                            {
		                                                "List": ["a", "b", "c"],
		                                                "IEnumerable": ["a", "b", "c"],
		                                                "ICollection": ["a", "b", "c"],
		                                                "IList": ["a", "b", "c"]
		                                            }
		                                            """)
			.ToString();
		var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
		var obj = await Json.DeserializeAsync<TestType>(stream);
		Assert.NotNull(obj);
		Assert.Equal(obj.List, ["a", "b", "c"]);
	}

	[Fact]
	public async Task HandlesNestedLists()
	{
		var jsonString = """
			{
				"NestedLists": [["a", "b"], ["c", "d"]],
				"DeeplyNestedLists": [[["a"]], [["b"]]]
			}
			""";
		var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
		var obj = await Json.DeserializeAsync<NestedListType>(stream);
		Assert.NotNull(obj);
		Assert.Equal(2, obj.NestedLists.Count);
		Assert.Equal(["a", "b"], obj.NestedLists[0]);
		Assert.Equal(["c", "d"], obj.NestedLists[1]);
		Assert.Equal(2, obj.DeeplyNestedLists.Count);
		Assert.Single(obj.DeeplyNestedLists[0]);
		Assert.Equal(["a"], obj.DeeplyNestedLists[0][0]);
	}

	[Fact]
	public async Task HandlesNestedListsWithEmptyString()
	{
		var jsonString = """
			{
				"NestedLists": "",
				"DeeplyNestedLists": ""
			}
			""";
		var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
		var obj = await Json.DeserializeAsync<NestedListType>(stream);
		Assert.NotNull(obj);
		Assert.Empty(obj.NestedLists);
		Assert.Empty(obj.DeeplyNestedLists);
	}
}
