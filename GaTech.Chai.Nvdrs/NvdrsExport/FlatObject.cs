using System.Text.Json;
using System.Text.Json.Nodes;
using Hl7.Fhir.Model;

namespace GaTech.Chai.Nvdrs;

public abstract class FlatObject
{
    JsonNode rootNode;
    byte[] flatSequence;

    public FlatObject(string filename)
    {
        // Create an instance of StreamReader to read from a file.
        FileStream SourceStream = File.Open(filename, FileMode.Open);
        JsonNode? jsonNode = JsonNode.Parse(SourceStream);

        if (jsonNode == null)
        {
            throw new JsonException(filename + " has no JSON nodes");
        }
        else
        {
            rootNode = jsonNode;
        }

        // create the flat data sequnce size.
        if (FlatSize <= 0)
        {
            throw new Exception(filename + " must contain length or greater than 0.");
        }

        flatSequence = new byte[FlatSize];
        for (int i = 0; i < FlatSize; i++)
        {
            flatSequence[i] = (byte)' ';
        }
    }

    public string? Version => rootNode["version"]!.GetValue<string>();
    public string? FlatType => rootNode["type"]!.GetValue<string>();
    public int FlatSize
    {
        get
        {
            if (rootNode == null)
            {
                return 0;
            }

            return rootNode["length"]!.GetValue<int>();
        }
    }

    public JsonArray DataArray => rootNode["data"]!.AsArray();

    public virtual void MapToNVDRS(Bundle bundle)
    {
        // Implement this in the child class
    }

    protected void StringWriteToData(JsonNode data, string value)
    {
        int start = data["firstColumn"]!.GetValue<int>();
        int end = data["lastColumn"]!.GetValue<int>();
        int length = end - start;
        int valueLength = value.Length;

        string alignedValue = "";
        for (int i = length; i >= 0; i--)
        {
            if (valueLength < 0)
            {
                alignedValue = " " + alignedValue;
            }
            else
            {
                alignedValue = value[--valueLength] + alignedValue;
            }
        }

        data["value"] = alignedValue;
    }

    public void PopulateSequence()
    {
        // loop through data and populate the byte sequence.
        foreach (JsonNode? data in DataArray)
        {
            int startIndex = data!["firstColumn"]!.GetValue<int>() - 1;
            int endIndex = data!["lastColumn"]!.GetValue<int>();

            string? nodeName = data["name"]!.GetValue<string>();
            string? value = data["value"]!.GetValue<string>();
            if (value != null && value != "")
            {
                try
                {
                    char[] valueCharacters = value.ToCharArray();
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        flatSequence[i] = Convert.ToByte(valueCharacters[i - startIndex]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + nodeName + " config has an issue(s)\n" + ex.Message);
                }
            }
        }
    }

    public void ExportToFile(string? filename = null)
    {
        if (filename == null || filename == "")
        {
            string dateTimeTag = DateTime.Now.ToString("MMddyyyyhmmtt");
            filename = FlatType + "_" + dateTimeTag + ".txt";
        }

        PopulateSequence();
        File.WriteAllBytes(filename, flatSequence);
    }
}

