
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

    useEffect(() => {
        fetch('https:localhost:7186/api/products')
            .then(response => response.json())
            .then(data => setProducts(data))
    }, []);
    return (
        <>
            <ProductList  products={ products} />

            </>)
}