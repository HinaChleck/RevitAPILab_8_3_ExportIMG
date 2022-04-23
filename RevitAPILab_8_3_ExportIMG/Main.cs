using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPILab_8_3_ExportIMG
{
    [Transaction(TransactionMode.Manual )]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
           
            Document doc = commandData.Application.ActiveUIDocument.Document;

            #region Лишнее (на случай печати нескольких листов)
            //List<ViewPlan> ImageExportList = ViewsUtils.GetFloorPlanViews(doc);

            //IList<ElementId> viewsIds = new List<ElementId>();//Лишнее. Требуется на случай печать нескольких видов

            //foreach (ViewPlan viewPlan in ImageExportList)
            //{
            //   viewsIds.Add(viewPlan.Id);
            //}

            //ImageExportList.Add(View.Id);
            #endregion

            ImageExportOptions imgExportOptions = new ImageExportOptions
            {
                ZoomType = ZoomFitType.FitToPage,
                PixelSize = 1024,
                FilePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\123img.jpeg",
                FitDirection = FitDirectionType.Horizontal,
                HLRandWFViewsFileType = ImageFileType.JPEGLossless,
                ImageResolution = ImageResolution.DPI_600,
                ExportRange = ExportRange.CurrentView,
                };
                doc.ExportImage(imgExportOptions);

            // BilledeExportOptions.SetViewsAndSheets(viewsIds);//используется только при экспорте нескольких видов, когда ExportRange не равен CurrentView          

            TaskDialog.Show("Экспорт", "Экспорт прошел удачно");
            return Result.Succeeded;
            
        }
    }
}
