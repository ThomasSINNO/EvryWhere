using System.Collections.Generic;


interface IDeepCloneable
{

}


public class CorrectionContainer
{
    public string level_name;
    public bool is_correct;
    public List<TagCorrectionsStruct> table;

    public CorrectionContainer()
    {
        level_name = "dummy_name";
        is_correct = false;
        table = new List<TagCorrectionsStruct>();
    }
    public CorrectionContainer(CorrectionContainer cc) : this()
    {
        level_name = cc.level_name;
        is_correct = cc.is_correct;
        table = new List<TagCorrectionsStruct>();
        foreach (TagCorrectionsStruct tcs in cc.table)
        {
            table.Add(new TagCorrectionsStruct(tcs));
        }

    }
};
public class TagCorrectionsStruct
{
    public string tag;
    public List<LastLevelCorrectionStruct> table;
    public bool is_correct;

    public TagCorrectionsStruct()
    {
        tag = "dummy_name";
        is_correct = false;
        table = new List<LastLevelCorrectionStruct>();
    }
    public TagCorrectionsStruct(TagCorrectionsStruct tcs) : this()
    {
        tag = tcs.tag;
        is_correct = tcs.is_correct;
        table = new List<LastLevelCorrectionStruct>();

        NameCorrectionStruct hotfix_ncs = new NameCorrectionStruct();
        ArrowCorrectionStruct hotfix_acs = new ArrowCorrectionStruct();

        foreach (LastLevelCorrectionStruct llcs in tcs.table)
        {
            //this is a very ugly hotfix
            if (llcs.GetType().Equals(hotfix_ncs.GetType()))
                table.Add(new NameCorrectionStruct((NameCorrectionStruct)llcs));
            else if (llcs.GetType().Equals(hotfix_acs.GetType()))
                table.Add(new ArrowCorrectionStruct((ArrowCorrectionStruct)llcs));
        }
    }

};


public class LastLevelCorrectionStruct
{
    public string name;
    public bool is_correct;

    public LastLevelCorrectionStruct()
    {
        name = "dummy_name";
        is_correct = false;
    }

    public LastLevelCorrectionStruct(LastLevelCorrectionStruct llcs) : this()
    {
        name = llcs.name;
        is_correct = llcs.is_correct;
    }

};


public class NameCorrectionStruct : LastLevelCorrectionStruct
{
    public List<string> table;

    public NameCorrectionStruct() : base()
    {
        table = new List<string>();
    }

    protected virtual LastLevelCorrectionStruct CreateInstanceForClone()
    {
        return new NameCorrectionStruct();
    }

    public NameCorrectionStruct(NameCorrectionStruct ncs) : base(ncs)
    {
        table = new List<string>();
        foreach (string str in ncs.table)
        {
            table.Add(string.Copy(str));
        }
    }

};

public class ArrowCorrectionStruct : LastLevelCorrectionStruct
{
    public static bool compareExactEquality(string a1, string a2, string b1, string b2)
    {
        return a1.Equals(a2) && b1.Equals(b2);
    }
    public static bool compareCrossedEquality(string a1, string a2, string b1, string b2)
    {
        return ((a1.Equals(a2) && b1.Equals(b2)) || (a1.Equals(b2) && b1.Equals(a2)));
    }

    public string name_start, name_end;
    public string multiplicity_start, multiplicity_end;
    public typearrow type_arrow;
    public string middle_link_to_arrow_start, middle_link_to_arrow_end;//one end of the arrow is pointing to a middle of another arrow 
    public typearrow type_arrow_middle_link;
    public string dump()
    {
        string r = "";
        r += "type_arrow: " + type_arrow + "\n";
        r += "name_start: " + name_start + "\n";
        r += "name_end: " + name_end + "\n";
        r += "multiplicity_start: " + multiplicity_start + "\n";
        r += "multiplicity_end: " + multiplicity_end + "\n";
        r += "middle_link_to_arrow_start: " + middle_link_to_arrow_start + "\n";
        r += "middle_link_to_arrow_end: " + middle_link_to_arrow_end + "\n";
        r += "type_arrow_middle_link: " + type_arrow_middle_link + "\n";
        return r;
    }


    public ArrowCorrectionStruct() : base()
    {
        name_start = "";
        name_end = "";
        multiplicity_start = "";
        multiplicity_end = "";
        type_arrow = typearrow.UNDEF;
        type_arrow_middle_link = typearrow.UNDEF;
        middle_link_to_arrow_start = "";
        middle_link_to_arrow_end = "";
    }

    public ArrowCorrectionStruct(ArrowCorrectionStruct acs) : base(acs)
    {
        name_start = acs.name_start;
        name_end = acs.name_end;
        multiplicity_end = acs.multiplicity_end;
        multiplicity_start = acs.multiplicity_start;
        type_arrow = acs.type_arrow;
        middle_link_to_arrow_start = acs.middle_link_to_arrow_start;
        middle_link_to_arrow_end = acs.middle_link_to_arrow_end;
    }

    //ends_false__true_middle ===> put to false if want to compare the direct ends, true if want to compare the ends linked by the middle of another arrow
    public bool compareEndsBasedOnType(bool ends_false__true_middle, ArrowCorrectionStruct acs)
    {
        string a1, a2, b1, b2;
        typearrow type_our_selection;
        if (ends_false__true_middle)
        {
            a1 = name_start;
            a2 = acs.name_start;
            b1 = name_end;
            b2 = acs.name_end;
            type_our_selection = this.type_arrow_middle_link;
        }
        else
        {
            a1 = multiplicity_start;
            a2 = acs.multiplicity_start;
            b1 = multiplicity_end;
            b2 = acs.multiplicity_end;
            type_our_selection = this.type_arrow;
        }
        //depending on the type sometimes the start/end choice does not matter since it's not really an arrow but a bidirectional line
        if (type_our_selection == typearrow.LINK || type_our_selection == typearrow.UNDEF || type_our_selection == typearrow.ASSO)
        {
            if (!compareCrossedEquality(a1, a2, b1, b2))
                return false;
        }
        else
        {
            if (!compareExactEquality(a1, a2, b1, b2))
                return false;
        }
        return true;


    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != this.GetType())
            return false;

        ArrowCorrectionStruct acs = (ArrowCorrectionStruct)obj;

        
        //if (!multiplicity_end.Equals(acs.multiplicity_end)
        //       || !multiplicity_start.Equals(acs.multiplicity_start)
        //      // || !type_arrow.Equals(acs.type_arrow)
        //   )
        //    return false;
        if (!multiplicity_end.Equals(acs.multiplicity_end)
               || !multiplicity_start.Equals(acs.multiplicity_start)
           )
            return false;
        if (!type_arrow.Equals(acs.type_arrow) && !acs.type_arrow.Equals(typearrow.UNDEF))
            return false;
        //depending on the type sometimes the start/end choice does not matter since it's not really an arrow but a bidirectional line
        //start by comparing the direct ends
        if (!compareEndsBasedOnType(false, acs))
            return false;
        //then the remote ends if they exist
        if (!compareEndsBasedOnType(true, acs))
            return false;

        return true;
    }



};