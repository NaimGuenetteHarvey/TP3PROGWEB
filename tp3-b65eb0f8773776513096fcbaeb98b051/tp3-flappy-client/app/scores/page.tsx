"use client";

import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card";
import { Eye, EyeOff } from "lucide-react";
import { useFlappyAPI } from "../_hooks/use-flappy-api";
import { useEffect, useState } from "react";

export default function Scores() {

    const { 
        // États
        publicScores, myScores,
        // Requêtes
        getBestPublicScores, getMyScores, toggleScoreVisibility 
    } = useFlappyAPI();

    // Lorsque cet état est true, la colonne de gauche s'affichera dans la page.
    const [isLogged, setIsLogged] = useState<boolean>(false);

    useEffect(() => {

        getBestPublicScores();
        const token = localStorage.getItem("token");
       if (token) {
        setIsLogged(true);
        getMyScores();
    }

    }, []);
    
    function formatScore(value : number){
        return Math.round(value * 100) / 100;
    }

    return (
        <div className="flex justify-center items-start gap-6">

            {/* Mes scores (Seulement visible si isLogged est true !) */}
            { isLogged &&
            <Card className="w-md">

                <CardHeader>
                    <CardTitle className="text-xl text-center">👤 Mes scores</CardTitle>
                    <CardDescription className="text-center">Cliquez sur l'oeil pour changer la visibilité d'un score.</CardDescription>
                </CardHeader>

                <CardContent className="py-3">

                    { myScores.length > 0 ?
                    <table className="w-full">
                        <thead>
                            <tr>
                                <th>Score</th>
                                <th>Chrono</th>
                                <th>Date</th>
                                <th>Visibilité</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                myScores.map(s => 
                                    <tr key={s.id} className="text-center">
                                        <td>{s.points}</td>
                                        <td>{formatScore(s.chrono)} s.</td>
                                        <td>{s.date}</td>
                                        <td onClick={() => toggleScoreVisibility(s.id)}>{s.visibilité ? <Eye /> : <EyeOff /> }</td>
                                    </tr>
                                )
                            }
                        </tbody>
                    </table>
                    :
                    <div className="text-center">Aucun score pour le moment.</div>
                    }

                </CardContent>

            </Card>
            }

            {/* Scores publics */}
            <Card className="w-md">


                <CardHeader>
                    <CardTitle className="text-xl text-center">🏆 Meilleurs scores</CardTitle>
                    <CardDescription className="text-center">Les 10 meilleurs scores publics.</CardDescription>
                </CardHeader>

                <CardContent className="py-3">

                    { publicScores.length > 0 ?
                    <table className="w-full">
                        <thead>
                            <tr>
                                <th>Pseudo</th>
                                <th>Score</th>
                                <th>Chrono</th>
                                <th>Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                publicScores.map(s => 
                                    <tr key={s.id} className="text-center">
                                        <td>{s.pseudo}</td>
                                        <td>{s.points}</td>
                                        <td>{formatScore(s.chrono)} s.</td>
                                        <td>{s.date}</td>
                                    </tr>
                                )
                            }
                        </tbody>
                    </table>

                    :
                    <div className="text-center">Aucun score pour le moment.</div>
                    }
                </CardContent>

            </Card>
        </div>
    );

}