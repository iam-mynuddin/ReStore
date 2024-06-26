
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import ProductList from "./ProductList"
import { useEffect } from "react";
import { fetchProductsAsync, productSelector } from "./catalogSlice";

//interface Props {
//    /* Same like view model in asp.net*/
//    products: Product[],
//    addProduct: ()=>void    
//}
export default function Catalog() {
    const products=useAppSelector(productSelector.selectAll);
    const {productsLoaded,status}=useAppSelector(state=>state.catalog);
    const dispatch=useAppDispatch();

    useEffect(() => {
        if(!productsLoaded) dispatch(fetchProductsAsync());
    },[productsLoaded,dispatch]);
    if(status.includes('pending')) return <LoadingComponent message="Loading products..."></LoadingComponent>
    return (
        <>
            <ProductList  products={products} />
            </>)
}