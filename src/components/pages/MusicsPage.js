import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import MusicList from '../MusicList';

import { fetchMusics } from '../../actions/musics'

class MusicsPage extends Component {
// we need
    static propTypes = {
        musics: PropTypes.object.isRequired
    }

    // mouting
    componentDidMount() {
        this.props.fetchMusics();
    }
    
    render() {
        // console.log('Props: ', this.props);
        return (
            <div>
                <h2>Musics Page</h2>
                <MusicList musics={this.props.musics}></MusicList>
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

// for using action methods
const mapDispatchToProps = {
    fetchMusics
}

export default connect(mapStateToProps, mapDispatchToProps) (MusicsPage)
