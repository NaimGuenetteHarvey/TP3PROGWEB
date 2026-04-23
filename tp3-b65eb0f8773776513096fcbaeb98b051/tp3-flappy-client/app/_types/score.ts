export class Score{

    constructor(
        public id : number,
        public Pseudo : string | null,
        public Date : string,
        public Chrono : number,
        public Points : number,
        public Visibilité : boolean
    ){}

}