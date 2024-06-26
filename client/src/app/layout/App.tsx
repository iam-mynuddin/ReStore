
import Header from "./Header";
import { Container, CssBaseline, createTheme } from "@mui/material";
import { ThemeProvider } from "@emotion/react";
import { useEffect, useState } from "react";
import { Outlet } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css'
import { getCookie } from "../util/util";
import agent from "../../api/agent";
//import { useStoreContext } from "../../context/StoreContext";
import LoadingComponent from "./LoadingComponent";
import { useDispatch } from "react-redux";
import { setBasket } from "../../features/basket/basketSlice";


function App() {
    const dispatch=useDispatch();
    const [darkMode, setDarkMode] = useState(false);
    const [loading,setLoading]=useState(true);

    useEffect(()=>{
        const buyerId=getCookie('buyerId');//'test'
        //console.log(buyerId);
        //buyerId='2e4bc7dd-4679-4804-81fc-4762eae84ab9';
        // console.log(buyerId);
        if(buyerId){
            agent.Basket.get()
            .then(basket=>dispatch(setBasket(basket)))
            .catch(error=>console.log(error))
            .finally(()=>setLoading(false));
        }
        else{
            setLoading(false);
        }
        
    },[dispatch])


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
    if(loading) return <LoadingComponent message="Getting Basket..!" />
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
