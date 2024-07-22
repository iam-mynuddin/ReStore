import { createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import { Product } from "../../app/models/product";
import agent from "../../api/agent";
import { RootState } from "@reduxjs/toolkit/query";

const productsAdapter = createEntityAdapter<Product>();

export const fetchProductsAsync = createAsyncThunk<Product[]>(
    'catalog/fetchProductsAsync',
    async (_,thunkAPI) => {
        try {
            return await agent.Catalog.list();
        }
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        catch (error:any) {
            // console.log(error);
            return thunkAPI.rejectWithValue(error.data)
        }
    }
)
export const fetchProductAsync = createAsyncThunk<Product,number>(
    'catalog/fetchProductAsync',
    async (productId,thunkAPI) => {
        try {
            return await agent.Catalog.details(productId);
        }
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        catch (error:any) {
            // console.log(error);
            return thunkAPI.rejectWithValue({error:error.data})
        }
    }
)

export const fetchFilters=createAsyncThunk(
    'catalog/fetchFilters',
    async(_,thunkAPI)=>{
        try{
            return agent.Catalog.fetchFilters();
        }
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        catch (error:any) {
            // console.log(error);
            return thunkAPI.rejectWithValue({error:error.data})
        }
    }
);

export const catalogSlice = createSlice({
    name: 'catalog',
    initialState: productsAdapter.getInitialState({
        productsLoaded: false,
        filtersLoaded:false,
        status: 'idle',
        brands:[],
        types:[]

    }),
    reducers: {},
    extraReducers: (builder => {
        builder.addCase(fetchProductsAsync.pending, (state) => {
            state.status = 'pendingFetchProducts';
        });
        builder.addCase(fetchProductsAsync.fulfilled, (state, action) => {
            productsAdapter.setAll(state, action.payload);
            state.status = 'idle';
            state.productsLoaded = true;

        });
        builder.addCase(fetchProductsAsync.rejected,(state,action)=>{
            console.log(action.payload);
            state.status='idle';
        });
        builder.addCase(fetchProductAsync.pending,(state)=>{
            state.status='pendingFetchProduct';
        });
        builder.addCase(fetchProductAsync.fulfilled,(state,action)=>{
            productsAdapter.upsertOne(state,action.payload);
            state.status='idle';
        });
        builder.addCase(fetchProductAsync.rejected,(state,action)=>{
            console.log(action.payload);
            state.status='idle';
        });
        builder.addCase(fetchFilters.pending,(state)=>{
            state.status='pendingFetchFilters';
        });
        builder.addCase(fetchFilters.fulfilled,(state,action)=>{
            state.brands=action.payload.brands;
            state.types=action.payload.types;
            state.filtersLoaded=true;
            state.status='idle';
        })
        builder.addCase(fetchFilters.rejected,(state,action)=>{
            state.status='idle';
            console.log(action.payload)
        })
    })
}
)


export const productSelector=productsAdapter.getSelectors((state:RootState)=>state.catalog);