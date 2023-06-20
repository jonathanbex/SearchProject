import React, { Component } from 'react';
import CircularProgress from '@mui/material/CircularProgress';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';
import Tooltip from '@mui/material/Tooltip';
import Typography from '@mui/material/Typography';
export class Search extends Component {
    static displayName = Search.name;

    constructor(props) {
        super(props);
        this.state = { loading: false, input: "", results: [], searched: false };
    }

    render() {
        const { loading } = this.state;

        let contents = loading
            ? <div style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                backgroundColor: "primary.main"
            }}>

                <CircularProgress color="success" />
            </div>
            : Search.renderPage(this);

        return (
            <div>
                {contents}
            </div>
        );
    }



    static renderPage(base) {
        return (
            <div>
                <Grid container>
                    <Grid item md={4} xs={12}></Grid>
                    <Grid item md={4} xs={12}>

                        <Box
                            sx={{
                                marginTop: 8,
                                display: 'flex',
                                flexDirection: 'column',
                                alignItems: 'center'
                            }}
                        >
                            <Paper variant="outlined" sx={{ p: { xs: 2, md: 3, backgroundColor: "lightBlue" } }}>
                                <Typography variant="h3" gutterBottom> Search</Typography>
                                <div className="form-group">
                                    <Tooltip title="Enter query">
                                        <input type="text" className="form-control" value={base.state.input} onChange={(e) => base.setInput(e.target.value)} onKeyDown={(e) => base.handleKeyDown(e)} />
                                    </Tooltip>
                                    <Tooltip title="Submit Request">
                                        <Button
                                            type="submit"
                                            fullWidth
                                            variant="contained"
                                            sx={{ mt: 3, mb: 2 }}
                                            onClick={(e) => base.search()}
                                        >
                                            Search
                                        </Button>
                                    </Tooltip>
                                </div>

                            </Paper>
                        </Box>
                    </Grid>
                    <Grid item md={4} xs={12}></Grid>
                    <Grid item md={4} xs={12}></Grid>
                    <Grid item md={4} xs={12}>
                        <div className="form-group">
                            {base.renderResult(base.state)}
                        </div>
                    </Grid>
                    <Grid item md={4} xs={12}></Grid>
                </Grid>
            </div>
        );
    }
    renderResult(state) {
        if (state.searched === false) return (<div></div>);
        else return (
            <div>
                {state.results.map(result =>
                    <div>
                        <Paper variant="outlined" sx={{ p: { xs: 2, md: 3, backgroundColor: "white" } }}>
                            <Typography variant="h5" >
                                {result.name}
                            </Typography>
                       </Paper>
                    <Paper variant="outlined" sx={{ p: { xs: 2, md: 3, backgroundColor: "lightGreen" } }}>
                      {result.totalResults.toLocaleString()} Results were found
                        </Paper>
                        <br/>
                    </div>
                )}
            </div>
        )
    }

    setInput = (input) => {
        this.setState({ input: input });
    }
    search = () => {
        var input = this.state.input;
        this.getResults(input);
    }

    handleKeyDown = (e) => {
        if (e.key === "Enter") this.search();
    }
    async getResults(input) {
        this.setState({ loading: true });
        const requestOptions = {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
        };
        fetch('/search/search/?input=' + input, requestOptions)
            .then(response => response.json())
            .then(data => { this.setState({ input: input, loading: false, results: data.results, searched: true }); })
            .catch(err => {
                alert(err);
                console.log("error", err);
            });



    }
}