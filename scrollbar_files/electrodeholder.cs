using UnityEngine;
using System.Collections;

using LitJson;

	
	public class electrodeholder {

		public string col1;
        public string col2;
        public string col3;
        public string col4;
        public string col5;
    	[JsonIgnore]
		public Transform myIgnoredTransform; // This object will be ignored by the json engine.

		public electrodeholder(){ }

	}
/*
	// Notice how some values have been changed.
	const string savedJsonString = @"{
		""myInt"" : 42,
		""myString"" : ""This value has ciiiihanged!"",
		""myFloat""  : 6.28318,
		""myBool""   : true,
		""myVector2"" : {
			""x"" : 8.0,
			""y"" : 8.0
		},
		""myVector3"" : {
			""x"" : 3.1415901184082,
			""y"" : 3.1415901184082,
			""z"" : 3.1415901184082
		},
		""myVector4"" : {
			""x"" : 6.28318023681641,
			""y"" : 6.28318023681641,
			""z"" : 6.28318023681641,
			""w"" : 6.28318023681641
		},
		""myQuaternion"" : {
			""x"" : 1.0,
			""y"" : 1.0,
			""z"" : 1.0,
			""w"" : 1.0
		},
		""myColor""      : {
			""r"" : 0.0,
			""g"" : 0.0,
			""b"" : 0.0,
			""a"" : 0.0
		},
		""myColor32""    : {
			""r"" : 85,
			""g"" : 127,
			""b"" : 255,
			""a"" : 0
		},
		""myBounds""     : {
			""center"" : {
				""x"" : 0.0,
				""y"" : 0.0,
				""z"" : 0.0
			},
			""size""   : {
				""x"" : 1.0,
				""y"" : 1.0,
				""z"" : 1.0
			}
		},
		""myRect""       : {
			""x"" : 10.0,
			""y"" : 10.0,
			""width"" : 25.0,
			""height"" : 25.0
		},
		""myRectOffset"" : {
			""top"" : 15,
			""left"" : 5,
			""bottom"" : 20,
			""right""  : 10
		},
		""myIntArray""   : [
			   12,
			   14,
			   16,
			   18,
			   20
			   ]
	}";

	void Start () {

		ExampleSerializedClass serializedClass = new ExampleSerializedClass();

		JsonWriter writer = new JsonWriter();
		writer.PrettyPrint = true;

		JsonMapper.ToJson(serializedClass,writer);

		string json = writer.ToString();
		Debug.Log("json" + json);

		// If you don't need a JsonWriter, use this.
		//string json = JsonMapper.ToJson(exampleClass);

		ExampleSerializedClass deserializedClass = JsonMapper.ToObject<ExampleSerializedClass>(savedJsonString);

		Debug.Log("deserializedClass." + deserializedClass.myString);


    }

}*/
