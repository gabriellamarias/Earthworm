import { Openfarm_data } from "./openfarm_data";

export class Plant {
    constructor(
        public openfarm_data: Openfarm_data = {attributes: {description: "", row_spacing:0, spread:0, height: 0, sowing_method: "",
        sun_requirements: "", growing_degree_days: 0, main_image_path: ""}},
        public name: string,
        public en_wikipedia_url: string,
        public perennial: string,
        public median_lifespan: number,
        public median_days_to_first_harvest: number,
        public median_days_to_last_harvest: number

    ){}
     

}