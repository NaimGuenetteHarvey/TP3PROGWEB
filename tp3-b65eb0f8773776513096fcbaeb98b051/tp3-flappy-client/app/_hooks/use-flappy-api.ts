import { useState } from "react";
import { Score } from "../_types/score";

const domain = "https://localhost:████/";

export function useFlappyAPI(){

    const [publicScores, setPublicScores] = useState<Score[]>([]);
    const [myScores, setMyScores] = useState<Score[]>([]);

    async function getBestPublicScores(){



    }

    async function getMyScores(){



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