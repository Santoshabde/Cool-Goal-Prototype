using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleConfigData : BaseConfig<TestConfigData>
{
    
}

public class TestConfigData : IValueKeyConfig
{
    public string key => levelID;

    public string levelID;
}
