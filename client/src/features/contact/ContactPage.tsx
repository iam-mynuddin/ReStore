import { Button, ButtonGroup, Typography } from "@mui/material";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { decrement, increment } from "./counterSlice";

export default function ContactPage() {
    const dispatch=useAppDispatch();
    const {data,title}=useAppSelector(state=>state.counter);

    return (
        <>
        <Typography variant="h5">
            {title} - {data}
        </Typography>
        <ButtonGroup>
            <Button variant="contained" onClick={()=>dispatch(increment(1))} color="primary">INCREMENT</Button>
            <Button variant="contained" onClick={()=>dispatch(decrement(1))} color="error">DECREMENT</Button>
            <Button variant="contained" onClick={()=>dispatch(increment(5))} color="error">INCREMENT By 5</Button>
        </ButtonGroup>
        </>
    )
}