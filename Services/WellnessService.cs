using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssayMe.Core.Services.Abstaction;
using AssayMe.Core.ViewModels.Cells;
using MvvmCross.ViewModels;


namespace AssayMe.Core.Services.Implementation
{
    public class WellnessService : IWellnessService
    {
        public async Task<List<WellnessItem>> GetItems(string id, bool isTestData)
        {
            if (isTestData)
            {
                string testDesription = "Take your first test \n\n" + 
                    "If you do not have any test strips, press Buy Test Strip";
                return new List<WellnessItem>()
                {
                    new WellnessItem(testDesription,"LEYKOCYTES","n/a",Models.Enums.WellnessType.Leukocytes,true),
                    new WellnessItem(testDesription,"NITRITE","n/a",Models.Enums.WellnessType.Nitrite,false),
                    new WellnessItem(testDesription,"UROBILINOGEN","n/a",Models.Enums.WellnessType.Uron,true),
                    new WellnessItem(testDesription,"PROTEIN","n/a",Models.Enums.WellnessType.Protein,false),
                    new WellnessItem(testDesription,"PH","n/a",Models.Enums.WellnessType.Ph,true)
                };
            }
            
            string testText1 = "BLOOD found in urine. Value 25 cacell/μl\n\n" +
                "Presence of hemoglobin indicates extensive or rapid intravascular destruction of red blood cells.\n\n" +
                "In any case, for further diagnosis, please contact your health provider.";

            string testText2 = "NITRITE found in urine. First pad\n\n" +
                "Some types of bacteria convert nitrates into nitrites. The presence of nitrites in urine is an indicator of bacteria in the urinary tract, which may be a sign of UTI, kidney infection, kidney stones, pelvic area tumor or a blockage in the urinary tract.\n\n" +
                "In any case, for further diagnosis, please contact your health provider.";

            return new List<WellnessItem>()
            {
                new WellnessItem(testText1,"LEYKOCYTES","Neg",Models.Enums.WellnessType.Leukocytes,true),
                new WellnessItem(testText2,"NITRITE","First pad",Models.Enums.WellnessType.Nitrite,false),
                new WellnessItem(testText1,"UROBILINOGEN","32 umol/1",Models.Enums.WellnessType.Uron,true),
                new WellnessItem(testText2,"PROTEIN","Trace",Models.Enums.WellnessType.Protein,false),
                new WellnessItem(testText1,"PH","4.5",Models.Enums.WellnessType.Ph,true),
                new WellnessItem(testText2,"BLOOD","10 cacell/ul",Models.Enums.WellnessType.Blood,false),
                new WellnessItem(testText1,"SPECIFIC GRAVITY","1.010",Models.Enums.WellnessType.SpecificGravity,true),
                new WellnessItem(testText2,"KETONE","4 mmol/l",Models.Enums.WellnessType.Ketnote,true),
                new WellnessItem(testText1,"BILIRUBIN","17 mmol/l",Models.Enums.WellnessType.Bilirubin,false),
                new WellnessItem(testText2,"GLUKOSE","Neg",Models.Enums.WellnessType.Glukose,true)

            };
        }

    }
}