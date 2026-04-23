import { useState } from "react";
import { Score } from "../_types/score";
import axios from "axios";
import { apiRequest } from "../interceptor";

const domain = "https://localhost:7279/";

export function useFlappyAPI(){

    const [publicScores, setPublicScores] = useState<Score[]>([]);
    const [myScores, setMyScores] = useState<Score[]>([]);
    

    async function getBestPublicScores(){
       const x = await apiRequest.get(domain + "api/Scores/GetBestScores");
       console.log(x.data);

        setPublicScores(x.data);
    }

    async function getMyScores(){
       const x = await apiRequest.get("https://localhost:7279/api/Scores/GetMyScores");
       console.log(x.data);

       setMyScores(x.data);
    }

    async function toggleScoreVisibility(id : number){
      await apiRequest.put("https://localhost:7279/api/Scores/ChangeScoreVisibility/" + id);

      await getMyScores();
      await getBestPublicScores();
    }

    return { 

        publicScores, myScores,
        getBestPublicScores, getMyScores, toggleScoreVisibility 
    };

}