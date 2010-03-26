using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBGIS.PluginEngine
{
    public class ItemDef:NBGIS.PluginEngine.IItemDef
    {
        bool m_Group;
        string m_ID;
        long m_SubType;
    
#region IItemDef 成员

public bool  Group
{
	  get 
	{
        return this.m_Group;
	}
	  set 
	{
        this.m_Group = value;
	}
}

public string  ID
{
	  get 
	{
        return this.m_ID;
	}
	  set 
	{
        this.m_ID = value;
	}
}

public long  Sybtype
{
	  get 
	{
        return m_SubType;
	}
	  set 
	{
        m_SubType = value;
	}
}

#endregion
}
}
