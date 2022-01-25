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

            try
            {
                this.openfarm_data.attributes.description = plant.openfarm_data.attributes.description;

            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                this.openfarm_data.attributes.description = "Not Available";
            }

            try
            { 
                string rowString = plant.openfarm_data.attributes.row_spacing.ToString();
                int row = int.Parse(rowString);
                this.openfarm_data.attributes.row_spacing = row;
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {               
                this.openfarm_data.attributes.row_spacing = 0;
            }

            try
            {
                string spreadString = plant.openfarm_data.attributes.spread.ToString();
                int spread = int.Parse(spreadString);
                this.openfarm_data.attributes.spread = spread;
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                this.openfarm_data.attributes.spread = 0;
            }

            try
            {
                string heightString = plant.openfarm_data.attributes.height.ToString();
                int height = int.Parse(heightString);
                this.openfarm_data.attributes.height = height;
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                this.openfarm_data.attributes.height = 0;
            }

            try
            {
                this.openfarm_data.attributes.sowing_method = plant.openfarm_data.attributes.sowing_method;
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                this.openfarm_data.attributes.sowing_method = "Not Available";
            }

            try
            {
                this.openfarm_data.attributes.sun_requirements = plant.openfarm_data.attributes.sun_requirements;
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                this.openfarm_data.attributes.sun_requirements = "Not Available";
            }

            try
            {
                string growingString = plant.openfarm_data.attributes.growing_degree_days.ToString();
                int growing = int.Parse(growingString);
                this.openfarm_data.attributes.growing_degree_days = growing;
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                this.openfarm_data.attributes.growing_degree_days = 0;
            }

            try
            {
                this.openfarm_data.attributes.main_image_path = plant.openfarm_data.attributes.main_image_path;
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
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
