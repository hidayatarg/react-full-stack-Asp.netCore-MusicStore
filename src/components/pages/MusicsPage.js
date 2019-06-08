import React, { Component } from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import MusicList from '../MusicList';

class MusicsPage extends Component {
// we need
    static propTypes = {
        musics: PropTypes.array.isRequired
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

export default connect(mapStateToProps) (MusicsPage)
