
import Catalog from "../../features/catalog/Catalog";
import Header from "./Header";
import { Container, CssBaseline, createTheme } from "@mui/material";
import { ThemeProvider } from "@emotion/react";
import { useState } from "react";

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
        <CssBaseline/>
            <Header darkMode={darkMode} handleThemeChange={handleThemeChange }></Header>
            <Container>
            <Catalog></Catalog>            
            </Container>
        </ThemeProvider>
    )
}

export default App
