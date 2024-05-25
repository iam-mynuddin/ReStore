import { Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, TextField, Typography } from "@mui/material";
import { ChangeEvent, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Product } from "../../app/models/product";
import agent from "../../api/agent";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStoreContext } from "../../context/StoreContext";
import { LoadingButton } from "@mui/lab";

export default function ProductDetails() {
    const {basket,setBasket,removeItem}=useStoreContext();
    const { id } = useParams<{ id: string }>();
    const [product, setProduct] = useState<Product | null>(null);
    const [loading, setLoading] = useState(true);   
    const [quantity, setQuantity] = useState(0);
    const [submitting, setSubmitting] = useState(false);
    const item=basket?.items.find(i=>i.productId==product?.id)



    useEffect(() => {
        if(item){
            setQuantity(item.quantity)
        }
        id && agent.Catalog.details(parseInt(id))
            .then(response => setProduct(response))
            .catch(error => console.log(error))
            .finally(() => setLoading(false))
    },[id,item]);

    function handleInputChange(event:ChangeEvent<HTMLInputElement>){
        const value=parseInt(event.currentTarget.value);
        if(value>=0)
        setQuantity(value);
    }

    function handleUpdateCart(){
        if(!product) return;
        setSubmitting(true);
        if(!item||quantity>item.quantity){
            const updatedQuantity=item?quantity-item.quantity:quantity;
            agent.Basket.addItem(product.id,updatedQuantity)
            .then(basket=>setBasket(basket))
            .catch(error=>console.log(error))
            .finally(()=>setSubmitting(false))            
        }
        else{
            const updatedQuantity=item.quantity-quantity;
            agent.Basket.removeItem(product.id,updatedQuantity)
            .then(()=>removeItem(product.id,updatedQuantity))
            .catch(error=>console.log(error))
            .finally(()=>setSubmitting(false))
        }
    }

    if (loading) return (<><LoadingComponent message="Getting product..."></LoadingComponent></>)
    if(!product) return(<><h3>Product not found!</h3></>)

    return (
        <Grid container spacing={6}>
            <Grid item xs={6}>
                <img src={product.pictureUrl} alt={product.name} style={{width:"100%"} }></img>
            </Grid>
            <Grid item xs={6}>
                <Typography variant="h3">{product.name}</Typography>
                <Divider sx={{ mb :2}}>
                </Divider>
                <Typography variant="h4" color="secondary">${(product.price / 100).toFixed(2)}</Typography>
                <TableContainer>
                    <Table>
                        <TableBody>
                            <TableRow>
                                <TableCell>Name</TableCell>
                                <TableCell>{ product.name}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Description</TableCell>
                                <TableCell>{product.description}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Type</TableCell>
                                <TableCell>{product.type}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Brand</TableCell>
                                <TableCell>{product.brand}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Quantity in stock</TableCell>
                                <TableCell>{product.quantityInStock}</TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>
                <Grid container spacing={2}>
                    <Grid item xs={6}>
                        <TextField
                        onChange={handleInputChange}
                        variant="outlined"
                        type="number"
                        label="Quantity in cart:"
                        fullWidth
                        value={quantity}>                            
                        </TextField>
                    </Grid>
                    <Grid item xs={6}>
                        <LoadingButton
                        disabled={item?.quantity===quantity||!item&&quantity===0}
                        loading={submitting}
                        onClick={handleUpdateCart}
                        sx={{height:"55px"}}
                        color="primary"
                        size="large"
                        variant="contained"
                        fullWidth>

                        {item?"Update quantity":"Add to cart"}
                        </LoadingButton>
                    </Grid>
                </Grid>

            </Grid>
        </Grid>
    )
}