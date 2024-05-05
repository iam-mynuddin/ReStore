import { useEffect, useState } from "react"

function App() {
    const [products, setProducts] = useState([
        {name:"Product1",price:100.00},
        {name:"Product2",price:200.00},
    ]);

useEffect(() => {
    fetch('https:localhost:7186')
        .then(response => response.json())
        .then(data => setProducts(data))});
function addProduct() {
    setProducts(prevState => [...prevState, { name: 'Product' + (prevState.length + 1),price:(100*prevState.length) }])
}
    return (
        <div>
            <h1>Products</h1>
            <ul>
                {products.map((item, index) => (
                    <li key={index}> {item.name} -{item.price}</li>)) }
            </ul>
            <button onClick={addProduct}> Add Product</button>
        </div>
    )
}

export default App
