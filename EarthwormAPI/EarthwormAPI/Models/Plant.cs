using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace EarthwormAPI.Models
{
    public class Plant
    {
        public Openfarm_data openfarm_data { get; set; } = new Openfarm_data();
        public string name { get; set; }
        public string en_wikipedia_url { get; set; }
        public bool perennial { get; set; }
        public long? median_lifespan { get; set; }
        public long? median_days_to_first_harvest { get; set; }
        public long? median_days_to_last_harvest { get; set; }

        public Plant()
        {

        }

        public Plant(dynamic plant)
        {
            this.name = plant.name;
            this.en_wikipedia_url = plant.en_wikipedia_url;
            this.perennial = plant.perennial;
            this.median_lifespan = plant.median_lifespan;
            this.median_days_to_first_harvest = plant.median_days_to_first_harvest;
            this.median_days_to_last_harvest = plant.median_days_to_last_harvest;

            //try
            //{
            //    this.openfarm_data = plant.openfarm_data;
            //}
            //catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            //{
            //    this.openfarm_data.attributes.description = "Not Available";
            //    this.openfarm_data.attributes.row_spacing = 0;
            //    this.openfarm_data.attributes.spread = 0;
            //    this.openfarm_data.attributes.height = 0;
            //    this.openfarm_data.attributes.sowing_method = "Not Available";
            //    this.openfarm_data.attributes.sun_requirements = "Not Available";
            //    this.openfarm_data.attributes.growing_degree_days = 0;
            //    this.openfarm_data.attributes.main_image_path = "Not Available";
            //}
            //var x = plant.openfarm_data.attributes.description.ToString();

            try
            {
                this.openfarm_data.attributes.description = plant.openfarm_data.attributes.description;
                this.openfarm_data.attributes.row_spacing = plant.openfarm_data.attributes.row_spacing;
                this.openfarm_data.attributes.spread = plant.openfarm_data.attributes.spread;
                this.openfarm_data.attributes.height = plant.openfarm_data.attributes.height;
                this.openfarm_data.attributes.sowing_method = plant.openfarm_data.attributes.sowing_method;
                this.openfarm_data.attributes.sun_requirements = plant.openfarm_data.attributes.sun_requirements;
                this.openfarm_data.attributes.growing_degree_days = plant.openfarm_data.attributes.growing_degree_days;
                this.openfarm_data.attributes.main_image_path = plant.openfarm_data.attributes.main_image_path;

            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                this.openfarm_data.attributes.description = "Not Available";
                this.openfarm_data.attributes.row_spacing = 0;
                this.openfarm_data.attributes.spread = 0;
                this.openfarm_data.attributes.height = 0;
                this.openfarm_data.attributes.sowing_method = "Not Available";
                this.openfarm_data.attributes.sun_requirements = "Not Available";
                this.openfarm_data.attributes.growing_degree_days = 0;
                this.openfarm_data.attributes.main_image_path = "Not Available";
            }

            //if (plant.openfarm_data.GetType().ToString() == "openfarm_data")
            //{
            //    this.openfarm_data = plant.openfarm_data;
            //}
            //else
            //{
            //    this.openfarm_data.attribute.description = "Not Available";
            //    this.openfarm_data.attribute.row_spacing = 0;
            //    this.openfarm_data.attribute.spread = 0;
            //    this.openfarm_data.attribute.height = 0;
            //    this.openfarm_data.attribute.sowing_method = "Not Available";
            //    this.openfarm_data.attribute.sun_requirements = "Not Available";
            //    this.openfarm_data.attribute.growing_degree_days = 0;
            //    this.openfarm_data.attribute.main_image_path = "Not Available";
            //}
        }
    }
}
