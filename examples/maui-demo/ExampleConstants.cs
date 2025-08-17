using Newtonsoft.Json.Schema;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Interpretation;
using Orbyss.Blazor.Syncfusion.DynamicGrid.Models;
using Orbyss.Components.Json.Models;

namespace Syncfusion.DynamicGrid.Demo
{
    internal static class ExampleConstants
    {
        public const string Data = "[{\"firstName\":\"Kevin\",\"surname\":\"Jackson\",\"dateOfBirth\":\"1954-08-26\",\"status\":\"Accepted\",\"integerValues\":[28,92,58,20],\"textValues\":[\"delta\",\"gamma\",\"alpha\",\"lambda\"],\"decimalValues\":[57.76,37.47,39.39]},{\"firstName\":\"Bob\",\"surname\":\"Martin\",\"dateOfBirth\":\"1990-06-10\",\"status\":\"Pending\",\"integerValues\":[160,157,178],\"textValues\":[\"lambda\",\"sigma\"],\"decimalValues\":[55.56,81.38]},{\"firstName\":\"Paula\",\"surname\":\"Martin\",\"dateOfBirth\":\"1999-03-06\",\"status\":\"Pending\",\"integerValues\":[165,138,66],\"textValues\":[\"sigma\",\"beta\",\"omega\",\"zeta\"],\"decimalValues\":[26.0,49.84,54.73]},{\"firstName\":\"Zach\",\"surname\":\"Martinez\",\"dateOfBirth\":\"1950-05-11\",\"status\":\"Pending\",\"integerValues\":[188,57,98],\"textValues\":[\"zeta\",\"gamma\",\"omega\",\"theta\"],\"decimalValues\":[51.24,60.7]},{\"firstName\":\"Laura\",\"surname\":\"Wilson\",\"dateOfBirth\":\"2006-12-09\",\"status\":\"Rejected\",\"integerValues\":[21,62,42],\"textValues\":[\"omega\",\"beta\",\"kappa\",\"alpha\"],\"decimalValues\":[82.21,73.37]},{\"firstName\":\"Charlie\",\"surname\":\"Martinez\",\"dateOfBirth\":\"1972-01-13\",\"status\":\"Pending\",\"integerValues\":[123,106],\"textValues\":[\"beta\",\"zeta\",\"kappa\",\"theta\"],\"decimalValues\":[36.48,87.72]},{\"firstName\":\"Rachel\",\"surname\":\"Thomas\",\"dateOfBirth\":\"1963-07-19\",\"status\":\"Accepted\",\"integerValues\":[186,138,79],\"textValues\":[\"beta\",\"lambda\",\"gamma\"],\"decimalValues\":[84.01,33.19]},{\"firstName\":\"Michael\",\"surname\":\"Williams\",\"dateOfBirth\":\"1961-12-19\",\"status\":\"Rejected\",\"integerValues\":[47,31],\"textValues\":[\"lambda\",\"kappa\",\"zeta\"],\"decimalValues\":[82.54,64.14,0.36]},{\"firstName\":\"Samuel\",\"surname\":\"Moore\",\"dateOfBirth\":\"1960-07-18\",\"status\":\"Pending\",\"integerValues\":[66,154,31],\"textValues\":[\"delta\",\"alpha\",\"lambda\",\"beta\"],\"decimalValues\":[51.44,1.3,66.83,86.41]},{\"firstName\":\"Tina\",\"surname\":\"Martinez\",\"dateOfBirth\":\"1988-10-01\",\"status\":\"Rejected\",\"integerValues\":[158,46],\"textValues\":[\"kappa\",\"beta\",\"zeta\",\"delta\"],\"decimalValues\":[14.44,15.15,72.79]},{\"firstName\":\"Kevin\",\"surname\":\"White\",\"dateOfBirth\":\"1990-10-08\",\"status\":\"Rejected\",\"integerValues\":[51,64,111],\"textValues\":[\"gamma\",\"alpha\"],\"decimalValues\":[45.55,10.11,99.9,83.99]},{\"firstName\":\"Diana\",\"surname\":\"Wilson\",\"dateOfBirth\":\"2003-06-24\",\"status\":\"Pending\",\"integerValues\":[46,184],\"textValues\":[\"omega\",\"sigma\",\"theta\"],\"decimalValues\":[79.71,57.2,93.99]},{\"firstName\":\"Wendy\",\"surname\":\"Smith\",\"dateOfBirth\":\"2009-08-18\",\"status\":\"Rejected\",\"integerValues\":[181,43,89,21],\"textValues\":[\"gamma\",\"lambda\",\"zeta\"],\"decimalValues\":[83.4,96.14]},{\"firstName\":\"Oliver\",\"surname\":\"Moore\",\"dateOfBirth\":\"1986-07-07\",\"status\":\"Accepted\",\"integerValues\":[63,133,135,158],\"textValues\":[\"gamma\",\"zeta\",\"kappa\"],\"decimalValues\":[93.89,17.2,50.43]},{\"firstName\":\"Zach\",\"surname\":\"Johnson\",\"dateOfBirth\":\"1980-11-15\",\"status\":\"Rejected\",\"integerValues\":[132,106],\"textValues\":[\"sigma\",\"alpha\",\"theta\",\"zeta\"],\"decimalValues\":[30.95,25.84]},{\"firstName\":\"Julia\",\"surname\":\"Jones\",\"dateOfBirth\":\"1980-06-29\",\"status\":\"Pending\",\"integerValues\":[61,43,66],\"textValues\":[\"beta\",\"omega\"],\"decimalValues\":[88.14,97.6]},{\"firstName\":\"Ian\",\"surname\":\"Martin\",\"dateOfBirth\":\"1986-01-25\",\"status\":\"Accepted\",\"integerValues\":[68,62,188,79],\"textValues\":[\"sigma\",\"omega\",\"delta\"],\"decimalValues\":[30.43,29.44,84.31]},{\"firstName\":\"Victor\",\"surname\":\"Thompson\",\"dateOfBirth\":\"1954-03-05\",\"status\":\"Accepted\",\"integerValues\":[57,14,59,68],\"textValues\":[\"kappa\",\"alpha\"],\"decimalValues\":[38.38,7.98]},{\"firstName\":\"Hannah\",\"surname\":\"Martin\",\"dateOfBirth\":\"2003-01-28\",\"status\":\"Rejected\",\"integerValues\":[149,109,196],\"textValues\":[\"kappa\",\"beta\"],\"decimalValues\":[8.49,10.59,40.38,1.05]},{\"firstName\":\"Laura\",\"surname\":\"Williams\",\"dateOfBirth\":\"1981-09-14\",\"status\":\"Rejected\",\"integerValues\":[35,162,43,75],\"textValues\":[\"omega\",\"zeta\",\"lambda\"],\"decimalValues\":[33.42,71.65,6.36]},{\"firstName\":\"Charlie\",\"surname\":\"Johnson\",\"dateOfBirth\":\"1965-01-17\",\"status\":\"Accepted\",\"integerValues\":[126,191,161,9],\"textValues\":[\"lambda\",\"zeta\",\"sigma\"],\"decimalValues\":[96.21,97.91,81.67]},{\"firstName\":\"George\",\"surname\":\"Johnson\",\"dateOfBirth\":\"1987-08-17\",\"status\":\"Accepted\",\"integerValues\":[184,72],\"textValues\":[\"gamma\",\"zeta\",\"sigma\"],\"decimalValues\":[82.21,40.36,38.99,73.89]},{\"firstName\":\"Tina\",\"surname\":\"Wilson\",\"dateOfBirth\":\"2000-08-29\",\"status\":\"Pending\",\"integerValues\":[101,198,17,197],\"textValues\":[\"delta\",\"omega\",\"sigma\",\"beta\"],\"decimalValues\":[47.6,2.47]},{\"firstName\":\"Hannah\",\"surname\":\"Smith\",\"dateOfBirth\":\"1994-01-08\",\"status\":\"Pending\",\"integerValues\":[30,111],\"textValues\":[\"beta\",\"theta\"],\"decimalValues\":[90.51,78.34,32.99]},{\"firstName\":\"Paula\",\"surname\":\"Garcia\",\"dateOfBirth\":\"1956-06-19\",\"status\":\"Accepted\",\"integerValues\":[50,12,67],\"textValues\":[\"beta\",\"omega\"],\"decimalValues\":[70.08,72.35,4.37,78.79]},{\"firstName\":\"Ian\",\"surname\":\"Johnson\",\"dateOfBirth\":\"1993-01-12\",\"status\":\"Rejected\",\"integerValues\":[85,83],\"textValues\":[\"omega\",\"lambda\"],\"decimalValues\":[48.68,46.16,61.38]},{\"firstName\":\"Samuel\",\"surname\":\"Davis\",\"dateOfBirth\":\"1955-05-23\",\"status\":\"Rejected\",\"integerValues\":[196,189,27],\"textValues\":[\"lambda\",\"delta\",\"sigma\",\"alpha\"],\"decimalValues\":[48.86,39.28]},{\"firstName\":\"Paula\",\"surname\":\"Martin\",\"dateOfBirth\":\"1960-09-20\",\"status\":\"Rejected\",\"integerValues\":[11,64],\"textValues\":[\"omega\",\"gamma\",\"alpha\"],\"decimalValues\":[17.13,36.26]},{\"firstName\":\"Charlie\",\"surname\":\"Moore\",\"dateOfBirth\":\"1966-12-27\",\"status\":\"Pending\",\"integerValues\":[156,2,56,86],\"textValues\":[\"beta\",\"delta\",\"omega\",\"sigma\"],\"decimalValues\":[26.77,20.23,29.84]},{\"firstName\":\"Oliver\",\"surname\":\"Martin\",\"dateOfBirth\":\"1974-06-27\",\"status\":\"Accepted\",\"integerValues\":[36,84],\"textValues\":[\"gamma\",\"alpha\",\"theta\",\"zeta\"],\"decimalValues\":[37.24,34.79,93.08]},{\"firstName\":\"Tina\",\"surname\":\"Wilson\",\"dateOfBirth\":\"2010-09-30\",\"status\":\"Accepted\",\"integerValues\":[149,103,162,86],\"textValues\":[\"alpha\",\"kappa\",\"delta\"],\"decimalValues\":[19.41,8.7,17.06,27.74]},{\"firstName\":\"Tina\",\"surname\":\"Davis\",\"dateOfBirth\":\"1973-03-29\",\"status\":\"Pending\",\"integerValues\":[74,184],\"textValues\":[\"lambda\",\"omega\"],\"decimalValues\":[51.26,32.14,55.8]},{\"firstName\":\"Xander\",\"surname\":\"Garcia\",\"dateOfBirth\":\"1987-05-12\",\"status\":\"Rejected\",\"integerValues\":[152,4,1],\"textValues\":[\"beta\",\"lambda\",\"kappa\"],\"decimalValues\":[6.36,51.68,18.98]},{\"firstName\":\"Nina\",\"surname\":\"Martinez\",\"dateOfBirth\":\"2003-03-12\",\"status\":\"Accepted\",\"integerValues\":[31,1,111,56],\"textValues\":[\"gamma\",\"lambda\",\"delta\",\"theta\"],\"decimalValues\":[89.01,20.83,17.83,16.29]},{\"firstName\":\"Ethan\",\"surname\":\"Brown\",\"dateOfBirth\":\"1975-12-12\",\"status\":\"Accepted\",\"integerValues\":[117,126,139],\"textValues\":[\"gamma\",\"alpha\"],\"decimalValues\":[96.48,54.4]},{\"firstName\":\"Diana\",\"surname\":\"Smith\",\"dateOfBirth\":\"1996-09-02\",\"status\":\"Rejected\",\"integerValues\":[37,122,192],\"textValues\":[\"beta\",\"zeta\",\"sigma\"],\"decimalValues\":[21.63,96.13,80.24]},{\"firstName\":\"Alice\",\"surname\":\"Taylor\",\"dateOfBirth\":\"1972-05-12\",\"status\":\"Accepted\",\"integerValues\":[53,16,35,194],\"textValues\":[\"zeta\",\"sigma\",\"kappa\",\"omega\"],\"decimalValues\":[80.07,74.62]},{\"firstName\":\"Bob\",\"surname\":\"Anderson\",\"dateOfBirth\":\"1996-12-25\",\"status\":\"Rejected\",\"integerValues\":[92,143,73,128],\"textValues\":[\"alpha\",\"gamma\",\"kappa\",\"sigma\"],\"decimalValues\":[29.73,15.45,54.15]},{\"firstName\":\"Kevin\",\"surname\":\"Davis\",\"dateOfBirth\":\"1962-05-30\",\"status\":\"Rejected\",\"integerValues\":[43,163],\"textValues\":[\"delta\",\"alpha\",\"sigma\"],\"decimalValues\":[51.01,96.27,98.99,55.78]},{\"firstName\":\"Nina\",\"surname\":\"White\",\"dateOfBirth\":\"1952-12-10\",\"status\":\"Accepted\",\"integerValues\":[146,3,69],\"textValues\":[\"zeta\",\"beta\"],\"decimalValues\":[59.49,3.35,34.46,56.27]},{\"firstName\":\"Ian\",\"surname\":\"Johnson\",\"dateOfBirth\":\"1999-08-15\",\"status\":\"Rejected\",\"integerValues\":[3,171,142,24],\"textValues\":[\"alpha\",\"beta\"],\"decimalValues\":[80.59,68.64]},{\"firstName\":\"George\",\"surname\":\"Thomas\",\"dateOfBirth\":\"1996-12-29\",\"status\":\"Pending\",\"integerValues\":[182,198],\"textValues\":[\"lambda\",\"kappa\",\"delta\",\"beta\"],\"decimalValues\":[59.54,58.95,48.5]},{\"firstName\":\"Yvonne\",\"surname\":\"Davis\",\"dateOfBirth\":\"1976-01-18\",\"status\":\"Rejected\",\"integerValues\":[78,173],\"textValues\":[\"lambda\",\"delta\"],\"decimalValues\":[21.94,94.15,39.66,52.42]},{\"firstName\":\"Quentin\",\"surname\":\"Martin\",\"dateOfBirth\":\"1968-02-13\",\"status\":\"Rejected\",\"integerValues\":[82,151],\"textValues\":[\"beta\",\"gamma\"],\"decimalValues\":[4.56,12.86,72.5]},{\"firstName\":\"Fiona\",\"surname\":\"Jackson\",\"dateOfBirth\":\"2006-07-17\",\"status\":\"Pending\",\"integerValues\":[81,99,159],\"textValues\":[\"alpha\",\"lambda\",\"delta\",\"zeta\"],\"decimalValues\":[89.81,65.38]},{\"firstName\":\"Diana\",\"surname\":\"Hernandez\",\"dateOfBirth\":\"1979-12-11\",\"status\":\"Rejected\",\"integerValues\":[137,134,166,157],\"textValues\":[\"gamma\",\"zeta\",\"lambda\",\"delta\"],\"decimalValues\":[56.94,68.4,89.87]},{\"firstName\":\"Alice\",\"surname\":\"Thompson\",\"dateOfBirth\":\"1960-11-30\",\"status\":\"Pending\",\"integerValues\":[29,98,11,55],\"textValues\":[\"omega\",\"sigma\",\"theta\"],\"decimalValues\":[24.5,76.27,16.51]},{\"firstName\":\"Victor\",\"surname\":\"Jackson\",\"dateOfBirth\":\"1980-04-02\",\"status\":\"Accepted\",\"integerValues\":[158,54],\"textValues\":[\"lambda\",\"beta\",\"sigma\",\"theta\"],\"decimalValues\":[44.09,14.71,10.75,37.01]},{\"firstName\":\"Samuel\",\"surname\":\"Anderson\",\"dateOfBirth\":\"1992-01-26\",\"status\":\"Pending\",\"integerValues\":[153,120,70],\"textValues\":[\"theta\",\"lambda\",\"kappa\",\"beta\"],\"decimalValues\":[62.37,55.74,68.82]},{\"firstName\":\"Wendy\",\"surname\":\"Smith\",\"dateOfBirth\":\"1980-02-15\",\"status\":\"Rejected\",\"integerValues\":[186,118,103,168],\"textValues\":[\"kappa\",\"sigma\",\"omega\",\"gamma\"],\"decimalValues\":[27.57,67.23,25.26,24.73]}]";

        public static readonly JSchema JsonSchema = JSchema.Parse(jsonSchema);

        public static readonly TableUiSchema TableUiSchema = DefaultJsonConverter.Deserialize<TableUiSchema>(uiSchema);

        public static readonly TranslationSchema TranslationSchema = DefaultJsonConverter.Deserialize<TranslationSchema>(translationSchema);

        private const string jsonSchema = @"
            {
                ""properties"":{
                    ""firstName"": {
                        ""type"": ""string""
                    },
                    ""surname"": {
                        ""type"": ""string""
                    },
                    ""dateOfBirth"": {
                        ""type"": ""string"",
                        ""format"": ""date""
                    },
                    ""status"": {
                        ""type"": ""string"",
                        ""enum"": [
                            ""Pending"",
                            ""Accepted"",
                            ""Rejected""
                        ]
                    },
                    ""integerValues"": {
                        ""type"": ""array"",
                        ""items"":{
                            ""type"": ""integer""                            
                        }
                    },
                    ""decimalValues"": {
                        ""type"": ""array"",
                        ""items"":{
                            ""type"": ""number""                            
                        }
                    },
                    ""textValues"": {
                        ""type"": ""array"",
                        ""items"":{
                            ""type"": ""string""
                        }
                    }
                }
            }";

        private const string uiSchema = @"
        {
            ""initialOrdering"":{
                ""direction"": ""descending"",
                ""scope"": ""$.properties.dateOfBirth""
            },
             ""columns"":{        
                 ""globalLayout"":{
                     ""width"": ""120"",
                     ""alignment"":{
                         ""horizontal"": ""right""
                     }
                 },
                 ""items"":[
                     {
                         ""label"": ""CustomFirstNameLabel"",
                         ""scope"": ""$.properties.firstName"",
                         ""sortable"": true,
                         ""filter"":{
                             ""types"":[
                                 ""header""
                             ],
                             ""rule"": ""StartsWith""
                         }
                     },
                     {
                         ""scope"": ""$.properties.surname"",
                         ""sortable"": true,
                         ""filter"":{
                             ""types"":[
                                 ""header""
                             ],
                             ""rule"": ""EndsWith""
                         }
                     },
                     {
                         ""scope"": ""$.properties.dateOfBirth"",
                         ""sortable"": true
                     },
                     {
                         ""scope"": ""$.properties.integerValues"",
                         ""sortable"": false,
                         ""filter"":{
                            ""types"":[
                                ""header""
                            ]
                         },
                         ""layout"": {
                             ""width"": ""90"",
                             ""alignment"":{
                                 ""horizontal"": ""center""
                             }
                         }
                     },
                     {
                         ""scope"": ""$.properties.decimalValues"",
                         ""sortable"": false,
                         ""filter"":{
                            ""types"":[
                                ""header""
                            ]
                         }
                     },
                     {
                         ""scope"": ""$.properties.textValues"",
                         ""sortable"": false,
                         ""filter"":{
                            ""types"":[
                                ""header""
                            ]
                         }
                     },
                     {
                         ""scope"": ""$.properties.status"",
                         ""sortable"": true,
                         ""filter"":{
                            ""types"":[
                                ""header""
                            ],
                            ""rule"": ""Equal""
                         },
                         ""layout"": {
                             ""width"": ""60"",
                             ""alignment"":{
                                 ""horizontal"": ""left""
                             }
                         }
                     }
                 ]
             }
         }";

        private const string translationSchema = @"
        {
            ""resources"":{
                ""en"":{
                    ""translation"":{
                        ""CustomFirstNameLabel"": ""First name!"",
                        ""surname"": ""Last name"",
                        ""dateOfBirth"":{
                            ""label"": ""Date of birth""
                        },
                        ""status"":{
                            ""label"": ""Status of person""                    
                        }
                    }
                },
                ""nl"":{
                    ""translation"":{
                        ""CustomFirstNameLabel"": ""Voornaam !"",
                        ""surname"": ""Achternaam"",
                        ""dateOfBirth"":{
                            ""label"": ""Geboorte datum""
                        },
                        ""status"":{
                            ""label"": ""Persoon status"",
                            ""Pending"": ""Afwachten"",
                            ""Accepted"": ""Goedgekeurd"",
                            ""Rejected"": ""Afgekeurd""
                        }
                    }
                }
            }
        }";
    }
}