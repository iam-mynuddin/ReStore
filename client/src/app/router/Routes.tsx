
import { createBrowserRouter } from "react-router-dom";
import App from "../layout/App";
import HomePage from "../../features/home/HomePage";
import ProductDetails from "../../features/catalog/ProductDetails";
import Catalog from "../../features/catalog/Catalog";
import AboutPage from "../../features/about/AboutPage";
import { ContactPage } from "@mui/icons-material";


export const router = createBrowserRouter([
    {
        path: "/",
        element: <App></App>,
        children: [
            { path: "/", element: <HomePage /> },
            { path: "home", element: <HomePage /> },
            { path: "catalog", element: <Catalog /> },
            { path: "catalog/:id", element: <ProductDetails /> },
            { path: "about", element: <AboutPage /> },
            { path: "contact", element: <ContactPage /> }
        ]
    }
]);