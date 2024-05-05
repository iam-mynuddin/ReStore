import { Product } from "../../app/models/product"

interface Props {
    /* Same like view model in asp.net*/
    products: Product[],
    addProduct: ()=>void    
}
export default function Catalog({ products,addProduct }:Props) {
    return (
        <>
            <ul>
                {products.map((product:any) => (
                    <li style={{ border: "solid 1px" }} key={product.id}> {product.name} -{product.price}
                        <img src={product.pictureUrl}></img>
                    </li>))}
            </ul>
            <button onClick={addProduct}> Add Product</button>
            </>)
}