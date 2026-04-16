import { useState } from "react";
import { Score } from "../_types/score";
import axios from "axios";

const domain = "https://localhost:7279/";

export function useFlappyAPI(){

    const [publicScores, setPublicScores] = useState<Score[]>([]);
    const [myScores, setMyScores] = useState<Score[]>([]);

    async function getBestPublicScores(){
       const x = await axios.get(domain + "api/Scores/GetBestScores");
       console.log(x.data);

        setPublicScores(x.data);



    }

    async function getMyScores(){
       const x = await axios.get(domain + "api/Scores/GetMyScores");
       console.log(x.data);

        setMyScores(x.data);



    }

    async function toggleScoreVisibility(id : number){



    }

    return { 

        // États
        publicScores, myScores,

        // Requêtes
        getBestPublicScores, getMyScores, toggleScoreVisibility 
    };

}