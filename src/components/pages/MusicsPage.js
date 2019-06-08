import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import MusicList from '../MusicList';

class MusicsPage extends Component {
// we need
    static propTypes = {
        musics: PropTypes.array.isRequired
    }

    state ={
        musics:[
            {
                name:'Tarkan'
            },
            {
                name:'Ajda Pekan'
            },
            {
                name:'Ibrahim Erkal'
            }
        ]
    }


    render() {
        // console.log('Props: ', this.props);
        return (
            <div>
                <h2>Musics Page</h2>
                <MusicList musics={this.state.musics}></MusicList>
            </div>
        )
    }
    }

// read State
const mapStateToProps = ({ musics }) => {
    return {
        musics
    }
}

export default connect(mapStateToProps) (MusicsPage)
