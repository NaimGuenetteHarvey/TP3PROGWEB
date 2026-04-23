import axios from "axios";
export const apiRequest = axios.create({
  baseURL: "https://localhost:7279/",
});

apiRequest.interceptors.request.use((config) => {
  config.headers["Content-Type"] = "application/json";
  
  const token = localStorage.getItem("token");
  
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});