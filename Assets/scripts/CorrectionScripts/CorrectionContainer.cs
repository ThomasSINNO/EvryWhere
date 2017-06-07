using System.Collections.Generic;



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
        table = new List<TagCorrectionsStruct>(cc.table);
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
        table = new List<LastLevelCorrectionStruct>(tcs.table);
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

    public NameCorrectionStruct(NameCorrectionStruct ncs) : base(ncs)
    {
        table = new List<string>(ncs.table);
    }

};

public class ArrowCorrectionStruct : LastLevelCorrectionStruct
{
  public  string name_start, name_end;
    public string multiplicity_start, multiplicity_end;
    public string type_arrow;
    public string middle_link_to_arrow_start, middle_link_to_arrow_end;

    public ArrowCorrectionStruct() : base()
    {
        name_start = "dummy_start_name";
        name_end = "dummy_name_end";
        multiplicity_start = "dummy_multiplicity_start";
        multiplicity_end = "dummy_multiplicity_end";
        type_arrow = "dummy_type_arrow";
        middle_link_to_arrow_start = "dummy_middle_link_to_arrow_start";
        middle_link_to_arrow_end = "dummy_middle_link_to_arrow_end";
    }

    public ArrowCorrectionStruct(ArrowCorrectionStruct ncs) : base(ncs)
    {
        name_start = ncs.name_start;
        name_end = ncs.name_end;
        multiplicity_end = ncs.multiplicity_end;
        multiplicity_start = ncs.multiplicity_start;
        type_arrow = ncs.type_arrow;
        middle_link_to_arrow_start = ncs.middle_link_to_arrow_start;
        middle_link_to_arrow_end = ncs.middle_link_to_arrow_end;
    }
    public override bool Equals(object obj)
    {
        if (obj.GetType() != this.GetType())
            return false;
        ArrowCorrectionStruct acs = (ArrowCorrectionStruct) obj;
        if (!name_start.Equals(acs.name_start)
               || !name_end.Equals(acs.name_end)
               || !multiplicity_end.Equals(acs.multiplicity_end)
               || !multiplicity_start.Equals(acs.multiplicity_start)
               || !type_arrow.Equals(acs.type_arrow)
               || !middle_link_to_arrow_start.Equals(acs.middle_link_to_arrow_start)
               || !middle_link_to_arrow_end.Equals(acs.middle_link_to_arrow_end)
           )
            return false;
        else
            return true;
    }

};
