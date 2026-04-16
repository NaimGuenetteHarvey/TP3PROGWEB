export class Score{

    constructor(
        public id : number,
        public username : string | null,
        public gameDate : string,
        public timeInSeconds : number,
        public scoreValue : number,
        public isPublic : boolean
    ){}

}