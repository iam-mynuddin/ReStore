
import agent from "../../api/agent";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { Product } from "../../app/models/product"
import ProductList from "./ProductList"
import { useEffect, useState } from "react";

//interface Props {
//    /* Same like view model in asp.net*/
//    products: Product[],
//    addProduct: ()=>void    
//}
export default function Catalog() {
    const [products, setProducts] = useState<Product[]>([]);
    const [loading, setLoading] = useState<boolean>(true);

    useEffect(() => {
        agent.Catalog.list()
        .then(products=>setProducts(products))
        .catch(error=>console.log(error))
        .finally(()=>setLoading(false))
    },[]);
    if(loading) return <LoadingComponent message="Loading products..."></LoadingComponent>
    return (
        <>
            <ProductList  products={products} />
            </>)
}