
import Header from "./Header";
import { Container, CssBaseline, createTheme } from "@mui/material";
import { ThemeProvider } from "@emotion/react";
import { useState } from "react";
import { Outlet } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css'

function App() {
    const [darkMode, setDarkMode] = useState(false);
    const palleteType=darkMode?"dark":"light"
    const theme = createTheme({
        palette: {
            mode: palleteType,
            background: {
                default:palleteType==="light"?"#eaeaea":"#121212"
            }
        }
    })
    function handleThemeChange() {
        setDarkMode(!darkMode);
    }
    return (
        <ThemeProvider theme={theme }>
            <ToastContainer position="bottom-right" hideProgressBar theme="colored"></ToastContainer>
        <CssBaseline/>
            <Header darkMode={darkMode} handleThemeChange={handleThemeChange }></Header>
            <Container>
            <Outlet></Outlet>            
            </Container>
        </ThemeProvider>
    )
}

export default App
