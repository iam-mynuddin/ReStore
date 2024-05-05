import { useEffect, useState } from "react"
import { Product } from "../models/product";
import Catalog from "../../features/catalog/Catalog";

function App() {
    const [products, setProducts] = useState<Product[]>([]);

useEffect(() => {
    fetch('https:localhost:7186/api/products/getproducts')
        .then(response => response.json())
        .then(data => setProducts(data))},[]);
function addProduct() {
    setProducts(prevState => [...prevState, {
        name: 'Product' + (prevState.length + 1)
        , price: (100 * prevState.length)
        , id: (prevState.length + 1)
        , description: 'Test'
        , pictureUrl: 'http://picsum.photos/200'
        , brand:'MyBrand'
}])
}
    return (
        <div>
            <h1>ReStore</h1>
            <Catalog products={products} addProduct={addProduct }></Catalog>
            
        </div>
    )
}

export default App
