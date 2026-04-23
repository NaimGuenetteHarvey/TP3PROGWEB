"use client";

import { useEffect, useState } from "react";
import { Game } from "./_types/gameLogic/game";
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { apiRequest } from "./interceptor";

export default function Home() {

  const game = new Game();
  const [scoreSent, setScoreSent] = useState<boolean>(false);

  useEffect(() => {

    game.prepareGame();

    return () => {
      location.reload(); // Crotté mais nécessaire pour ne pas que le jeu se duplique
    }

  }, []);

  async function postScore() {
    if (scoreSent) return;
    setScoreSent(true);
    

    const score = sessionStorage.getItem("score");
    const time = sessionStorage.getItem("time");
    
    const newScore = {
        points: Number(score),
        chrono: Number(time)
    };
    const x = await apiRequest.post("https://localhost:7279/api/Scores/PostScore", newScore);
    console.log(x.data);

    // 💡 Le SCORE et le CHRONO peuvent être récupérés dans
    // sessionStorage.getItem("score") et sessionStorage.getItem("time")
    // Attention ! Ils ont été « stringifiés » car ce sont des « number ».

    // Une requête à ajouter ici (POST)

  }

  function replay() {

    game.prepareGame();
    setScoreSent(false);

  }

  return (
    <div>
      <div className="playZone">
        <div id="game">
          <div id="score">0</div>
          <img id="birbgreen" src="/images/duo_green_0.png" alt="Duo" style={{ visibility: 'hidden', top: '500px', left: '218px' }} />
          <img id="birbblue" src="/images/duo_blue_0.png" alt="Duo" style={{ visibility: 'hidden', top: '500px', left: '218px' }} />
          <div id="startMsg">Appuyer sur W et E pour commencer.</div>
          <hr id="limit" />
        </div>
      </div>

      <div id="darkScreen" style={{ visibility: 'hidden' }}>
        <Card className="w-sm pb-0 absolute gap-3" id="scorePanel">

          <CardHeader>
            <CardTitle className="text-xl">Partie terminée !</CardTitle>
          </CardHeader>

          <CardContent className="py-1">
            <div className="text-center text-xl" id="lastScore">Score : 0</div>
            <br />
            <img className="m-auto" id="reaction" src="/images/sad.png" alt="Duo" />
          </CardContent>

          <CardFooter className="flex-col gap-2 bg-muted/50 border-t rounded-b-xl pb-5">
            {
              !scoreSent && <Button onClick={postScore} className="w-full font-bold cursor-pointer">Envoyer le score</Button>
            }
            <Button onClick={replay} className="w-full font-bold cursor-pointer">Fermer</Button>
            
          </CardFooter>

        </Card>
      </div>
    </div>
  );
}
