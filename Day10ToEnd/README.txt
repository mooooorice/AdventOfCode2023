Day10 Idea:
Read the entire input into a matrix (2D array) (find the coordinate of S while reading in the input)
From S, check all surrounding coordinates if it can move there

Global variables:
matrix input
matrix visited



It should make it an array/list of inputs, to proceed all paths at the same time by the same amount
It should be a function that takes an object as input and returns an object, the object contains the following fields:
    sourceDirection // where one came from
    coordinate // where it is currently
    distance // how far it is from the start
    
    
New idea:
    Have the following object:
        int[2] nextTileCoordinate (x is equal or less than 4)
        char sourceDirection (is one of the following: L, R, U, D)
    Have a list of those objects
    Set distance to 0
    Have the following function in a while loop:
        check if one of the nextTileCoordinates is equal to one of the others
        If yes:
            end loop and resturn distance +1
        If no: 
            distance++
            for each of the objects in the list, check if nexttileCoordinate is reachable from the sourceDirection
            If yes:
                Update it's values?
            If no:
                Remove it from the list?
                
Pseudo Code:
    class PipePosition{
        int[2] nextTileCoordinate;
        char sourceDirection;
    }
    
    int distance = 0;
    List<PipePosition> currentPositions = positionsAdjacentToStart();
    while(!hasCompleteLoop(currentPositions)){
        currentPositions = getNextPositions(currentPositions)
    }
        
    hasCompleteLoop(ImuatebleList<PipePosition> currentPositions){
        foreach(currentPosition in currentPositions){
            foreach(currentOtherPosition in currentPositions){
                if(currentOtherPosition != currentPosition && currentOtherPosition.nextTileCooridnate.Equals(currentPosition.nextTileCoordinate) => return true;
            }
        }
        return false;
    }
    
    getNextpositions(ImuatbleList<PipePosition> currentPositions){
        List<PipePositions> nextPipePositions;
        foreach(currentPosition in currentPositions){
            if(nextTileCooridnateIsReachableFromSourceDirection(currentPosition)){
                try{
                    nextPipePositions.Add(getNextPipePosition(currentPosition))
                }catch(error)
            }
        }
        return nextPipePositions
    }
    
    // // // Continue here: //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  // 
    nextTileCooridnateIsReachableFromSourceDirection(PipePosition currentPosition){
        if(matrixInput[nextTilePosition.x][nextTilePosition.y].isReachableFrom(prevLocation))
    }
    
    getNextPipePosition(){
        
    }
    
    
    Create the object for all directions and let it run
    If it reaches a stop, destory it/remove it from the collection

Have a function that does the following:
    Parameters: direction from where it comes (L, R, U, D) -> sourceDirection, coordinate of the target -> coordinates
    Return value: int representing the number of steps (will call itself, and therefore return the value from the called function +1)
    Function: 
        it checks if it can go to this location from the previous location ('-' is not accessible from U/D)
        if no:
            it returns -1
        if yes:
            it marks the locaiton as visited in the matrix visited
            
        