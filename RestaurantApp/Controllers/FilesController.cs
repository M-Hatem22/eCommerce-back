using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.APIs.tinyParserMapper;
using RestaurantApp.BL;
using RestaurantApp.BL.DTOs.files;
using RestaurantApp.BL.DTOs.Items;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;
using TinyCsvParser;



namespace RestaurantApp.APIs.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    private readonly IItemsManager itemManager;
    public FilesController(IItemsManager itemManager)
    {
        this.itemManager = itemManager;
    }
    [HttpPost]
    [Route("/image")]
    public ActionResult<uploadFileResult> uploadImage(IFormFile file)
    {
        #region checkExtention
        // to be put in appsettings.json
        var allowedExtensions = new string[]
        {
            ".png",
            ".jpeg",
            ".svg"
        };
       var extension = Path.GetExtension(file.FileName);
        bool extensionIsAllowed = allowedExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase);
        if (!extensionIsAllowed)
        {
            return BadRequest(new uploadFileResult(false, "extension Not Valid"));
        }
        #endregion
        #region checkFileLength
        //accept size till 4mb
        bool isLengthAllowed = file.Length is > 0 and <= 4_000_000;
        if(!isLengthAllowed)
        {
            return BadRequest(new uploadFileResult(false, "size not allowed"));
        }
        #endregion
        #region storeFile
        var fileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(Environment.CurrentDirectory, "Images");
        var fullFilePath = Path.Combine(filePath, fileName);
        
        using var stream = new FileStream(fullFilePath, FileMode.Create);
        file.CopyTo(stream);
        #endregion
        #region generateUrl
        var url = $"{Request.Scheme}://{Request.Host}/Images/{fileName}";
        return new uploadFileResult(true,"Success",url);
        #endregion
    }

    [HttpPost]
    [Route("/excel")]
    public ActionResult<uploadFileResult> uploadExcell (IFormFile excelFile)
    {
        #region checkExtention
        // to be put in appsettings.json
        var allowedExtensions = new string[]
        {
            ".csv"
        };
        var extension = Path.GetExtension(excelFile.FileName);
        bool extensionIsAllowed = allowedExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase);
        if (!extensionIsAllowed)
        {
            return BadRequest(new uploadFileResult(false, "extension Not Valid"));
        }
        #endregion
        #region checkFileLength
        //accept size till 4mb
        bool isLengthAllowed = excelFile.Length is > 0 and <= 4_000_000;
        if (!isLengthAllowed)
        {
            return BadRequest(new uploadFileResult(false, "size not allowed"));
        }
        #endregion
        #region storeFile
        var fileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(Environment.CurrentDirectory, "excel_imports");
        var fullFilePath = Path.Combine(filePath, fileName);

        using var stream = new FileStream(fullFilePath, FileMode.Create);
        excelFile.CopyTo(stream);
        #endregion
        #region generateUrl
        var url = $"{Request.Scheme}://{Request.Host}/excell/{fileName}";
        return new uploadFileResult(true, "Success", url);
        #endregion
    }

    [HttpPost]
    public ActionResult HandleExcelFile(IFormFile excelFile)
    {
        var csvProducts = GetProductsFromCsvFile(excelFile);
        itemManager.AddItemByList(csvProducts);
        
        return Ok();
    }


    [HttpGet]
    [Route("api/getAllItemsExcell")]
    public ActionResult GetExcelFile()
    {
        var records = itemManager.GetItems();
        using var writer = new StringWriter();
        
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

        csv.WriteRecords(records);

        var result = writer.ToString();

        //var products = csvProducts.Select(csvProduct => new Product { });
        //context.AddRange(products);
        //context.SaveChanges();
        return File(Encoding.UTF8.GetBytes(result), "text/csv", "inventory.csv");
        //return Ok();
    }

    private IEnumerable<ItemAddDto> GetProductsFromCsvFile(IFormFile file)
    {
        var csvParserOptions = new CsvParserOptions(true, ',');
        var csvMapper = new CsvProductMapping();
        var csvParser = new CsvParser<ItemAddDto>(csvParserOptions, csvMapper);

        using var reader = new StreamReader(file.OpenReadStream());
        return csvParser
            .ReadFromStream(reader.BaseStream, Encoding.ASCII)
            .Select(mappingResult => mappingResult.Result)
            .ToList();
    }
}

public class Foo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

