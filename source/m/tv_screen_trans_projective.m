clear all; 
close all; 
clc;

img = imread('TV_Screen.png');
imshow(img);

movingPoints = [62 59; 420 112; 425 300; 50 265];
fixedPoints = [0 0; size(img,2) 0; size(img,2) size(img,1); 0 size(img,1)];

tform = fitgeotrans(movingPoints, fixedPoints, 'Projective');

RA = imref2d([size(img,1) size(img,2)], [1 size(img,2)], [1 size(img,1)]);

[out,r] = imwarp(img, tform, 'OutputView', RA);
figure, imshow(out,r);

