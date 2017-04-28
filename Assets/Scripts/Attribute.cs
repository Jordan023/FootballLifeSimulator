using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attribute {

    private string attributeName;
    private int attributeLevel;
    private int attributeExp;

    public string AttributeName
    {
        get { return attributeName; }
        set { attributeName = value; }
    }

    public int AttributeLevel
    {
        get { return attributeLevel; }
        set { attributeLevel = value; }
    }

    public int AttributeExp
    {
        get { return attributeExp; }
        set { attributeExp = value; }
    }

    public Attribute(string attributeName, int attributeLevel, int attributeExp)
    {
        this.AttributeName = attributeName;
        this.AttributeLevel = attributeLevel;
        this.AttributeExp = attributeExp;
    }

    public bool levelUp()
    {
        if (AttributeExp >= 100)
        {
            if (AttributeLevel == 100)
                AttributeExp = 100;
            else
            {
                AttributeLevel++;
                AttributeExp = AttributeExp % 100;
                return true;
            }
        }

        return false;
    }

    public void addExperience()
    {
        AttributeExp = AttributeExp + (int)(11 * (Mathf.Exp((Mathf.Log(0.05f) / 100) * AttributeLevel)));
    }
}
