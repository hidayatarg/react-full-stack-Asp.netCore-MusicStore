import React from 'react'
import PropTypes from 'prop-types'

// stateless component
const MusicList = ({musics}) => {
    const emptyMessage = (
        <p>There are no Musics yet.</p>
    );


    const musicList = (
        <p>There are Musics</p>        
    )
    console.log('gelen musics: ', musics);
    
    return(
        <div>
            {
                musics.length === 0 ? emptyMessage : musicList
            }
        </div>
    )
}

MusicList.prototype = {
    // state movies convert to array
    musics: PropTypes.shape({
        musics: PropTypes.array.isRequired,
    }).isRequired
}

export default MusicList