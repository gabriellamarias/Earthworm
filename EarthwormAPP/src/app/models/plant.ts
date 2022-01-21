import { Openfarm_data } from "./openfarm_data";

export class Plant {
    constructor(
        public openfarm_data: Openfarm_data,
        public name: string,
        public en_wikipedia_url: string,
        public perennial: string,
        public median_lifespan: number,
        public median_days_to_first_harvest: number,
        public median_days_to_last_harvest: number

    ){}
     

}