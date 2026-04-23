import axios from "axios";

const domain = "https://localhost:7279/";

export function useAuth() {

    async function register(username: string, password: string, passwordConfirm: string) {
        const registerDTO = {
            username,
            password,
            passwordConfirm,
        };
            const x = await axios.post(domain + "api/Users/Register", registerDTO);
            console.log(x.data);
    }

    async function login(username: string, password: string) {
        
        const x = await axios.post(domain + "api/Users/Login", {
            username : username,
            password : password
        });
        console.log(x.data);

        localStorage.setItem("token", x.data.token);
    }
    
     

    return { register, login };

}