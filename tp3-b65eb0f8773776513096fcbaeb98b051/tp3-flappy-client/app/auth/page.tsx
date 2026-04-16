"use client";

import { Button } from "@/components/ui/button";
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { useAuth } from "../_hooks/use-auth";
import { useState } from "react";

export default function Auth() {

    const { register, login } = useAuth();

    // Inputs inscription
    const [regName, setRegName] = useState("");
    const [regPass, setRegPass] = useState("");
    const [regPassCon, setRegPassCon] = useState("");

    // Inputs connexion
    const [logName, setLogName] = useState("");
    const [logPass, setLogPass] = useState("");

    return (
        <div className="flex justify-center items-start gap-6">

            {/* Inscription */}
            <Card className="w-sm pb-0">
                <form onSubmit={(e) => {e.preventDefault(); register(regName, regPass, regPassCon) }}>

                    <CardHeader>
                        <CardTitle className="text-xl">Inscription</CardTitle>
                        <CardDescription>Choisissez un nom d'utilisateur et un mot de passe pour vous inscrire.</CardDescription>
                    </CardHeader>

                    <CardContent className="py-5">
                        <Label className="mb-2">Nom d'utilisateur</Label>
                        <Input type="text" placeholder="bob" value={regName} onChange={(e) => setRegName(e.target.value)}></Input>
                        <Label className="mb-2 mt-4">Mot de passe</Label>
                        <Input type="password" placeholder="salut" value={regPass} onChange={(e) => setRegPass(e.target.value)}></Input>
                        <Label className="mb-2 mt-4">Confirmer le mot de passe</Label>
                        <Input type="password" placeholder="salut" value={regPassCon} onChange={(e) => setRegPassCon(e.target.value)}></Input>
                    </CardContent>

                    <CardFooter className="flex-col gap-2 bg-muted/50 border-t rounded-b-xl pb-5">
                        <Button type="submit" className="w-full font-bold cursor-pointer">S'inscrire</Button>
                    </CardFooter>

                </form>
            </Card>

            {/* Connexion */}
            <Card className="w-sm pb-0">
                <form onSubmit={(e) => {e.preventDefault(); login(logName, logPass) }}>
                    
                    <CardHeader>
                        <CardTitle className="text-xl">Connexion</CardTitle>
                        <CardDescription>Entrez votre nom d'utilisateur et votre mot de passe pour vous connecter.</CardDescription>
                    </CardHeader>

                    <CardContent className="pt-5 pb-[94px]">
                        <Label className="mb-2">Nom d'utilisateur</Label>
                        <Input type="text" value={logName} onChange={(e) => setLogName(e.target.value)}></Input>
                        <Label className="mb-2 mt-4">Mot de passe</Label>
                        <Input type="password" value={logPass} onChange={(e) => setLogPass(e.target.value)}></Input>
                    </CardContent>

                    <CardFooter className="flex-col gap-2 bg-muted/50 border-t rounded-b-xl pb-5">
                        <Button type="submit" className="w-full font-bold cursor-pointer">Se connecter</Button>
                    </CardFooter>
                    
                </form>
            </Card>
        </div>
    );

}