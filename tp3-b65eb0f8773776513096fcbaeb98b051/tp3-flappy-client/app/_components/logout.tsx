"use client";

import { Alert, AlertTitle } from "@/components/ui/alert";
import { Button } from "@/components/ui/button";
import { InfoIcon } from "lucide-react";
import { useState } from "react";

export default function Logout() {

    const [alertOn, setAlertOn] = useState<boolean>(false);

    function logout() {

        setAlertOn(true);
        
        // Supprimer le token ici !
        localStorage.removeItem("token");

    }

    return (
        <div>
            <a onClick={logout} className="navButton">🚪 Déconnexion</a>
            {
                alertOn &&
                <div className="darkScreen" onClick={() => setAlertOn(false)}>
                    <Alert className="absolute">
                        <InfoIcon />
                        <AlertTitle>Vous êtes déconnecté(e)</AlertTitle>
                        <Button variant="outline" className="logoutCool">Ok cool</Button>
                    </Alert>
                </div>
            }
        </div>


    );

}