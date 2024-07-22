
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import ProductList from "./ProductList"
import { useEffect } from "react";
import { fetchFilters, fetchProductsAsync, productSelector } from "./catalogSlice";
import { Checkbox, FormControl, FormControlLabel, FormGroup, FormLabel, Grid, Paper, Radio, RadioGroup, TextField } from "@mui/material";

const sortOptions = [
    { value: 'name', label: 'A-Z' },
    { value: 'priceDesc', label: 'Price High - Low' },
    { value: 'price', label: 'Price Low - High' },
]

//interface Props {
//    /* Same like view model in asp.net*/
//    products: Product[],
//    addProduct: ()=>void    
//}
export default function Catalog() {
    const products = useAppSelector(productSelector.selectAll);
    const { productsLoaded, status, filtersLoaded } = useAppSelector(state => state.catalog);
    const dispatch = useAppDispatch();

    useEffect(() => {
        if (!productsLoaded) dispatch(fetchProductsAsync());
    }, [productsLoaded, dispatch]);
    useEffect(() => {
        if (!filtersLoaded) dispatch(fetchFilters());
    }, [filtersLoaded, dispatch])


    if (status.includes('pending')) return <LoadingComponent message="Loading products..."></LoadingComponent>
    return (
        <>
            <Grid container spacing={4}>
                <Grid item xs={3}>
                    <Paper sx={{ mb: 2 }}>
                        <TextField label="Search Products"
                            variant="outlined"
                            fullWidth
                        >
                        </TextField>
                    </Paper>
                    <Paper sx={{ mb: 2, p: 2 }}>
                        <FormControl>
                            <FormLabel id="demo-radio-buttons-group-label">Sort By:</FormLabel>
                            <RadioGroup>
                                {
                                    sortOptions.map(({ value, label }) => (
                                        <FormControlLabel value={value} control={<Radio />} label={label} />
                                    ))
                                }
                            </RadioGroup>
                        </FormControl>
                    </Paper>
                    <Paper sx={{ mb: 2, p: 2 }}>
                        <FormControl>
                            <FormLabel id="demo-radio-buttons-group-label">Filter by brand:</FormLabel>
                            <FormGroup>
  <FormControlLabel control={<Checkbox defaultChecked />} label="Label" />
  <FormControlLabel required control={<Checkbox />} label="Required" />
  <FormControlLabel disabled control={<Checkbox />} label="Disabled" />
</FormGroup>
                        </FormControl>
                    </Paper>

                </Grid>
                <Grid item xs={9}>

                    <ProductList products={products} />
                </Grid>

            </Grid>
        </>)
}